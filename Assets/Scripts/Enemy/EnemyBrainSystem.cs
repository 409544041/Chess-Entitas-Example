using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class EnemyBrainSystem : IInitializeSystem, IExecuteSystem
{
    private Contexts _contexts;
    private float _moveDelay;
    private float _timeStamp;
    private static readonly int[] PosibleX = { -2, -1, 1, 2, -2, -1, 1, 2 };
    private static readonly int[] PosibleY = { -1, -2, -2, -1, 1, 2, 2, 1 };

    public EnemyBrainSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _moveDelay = _contexts.config.gameConfig.value.EnemyMoveDelay;
        _timeStamp = Time.time + _moveDelay;
    }

    public void Execute()
    {
        if (Time.time >= _timeStamp)
        {
            _timeStamp += _moveDelay;
            Move();
        }
    }

    private void Move()
    {
        _contexts.game.enemyEntity.ReplacePosition(FindPath());
    }

    private Vector2Int FindPath()
    {
        Vector2Int startPos = _contexts.game.enemyEntity.position.value;
        Vector2Int targetPos = _contexts.game.playerEntity.position.value;
        
        Queue<Cell> cells = new Queue<Cell>();
        cells.Enqueue(new Cell(startPos.x, startPos.y, 0));

        List<Cell> reachedCells = new List<Cell>();
        Cell current;
        int x, y;
        Vector2Int boardSize = _contexts.config.gameConfig.value.BoardSize;
        bool[,] visit = new bool[boardSize.x, boardSize.y];

        visit[startPos.x, startPos.y] = true;
        while (cells.Count > 0)
        {
            current = cells.Dequeue();
  
            // if current cell is equal to target cell,  
            // return its distance  
            if (current.x == targetPos.x && current.y == targetPos.y)
            {
                reachedCells.Add(current);
            }  
  
            // loop for all reachable states  
            for (int i = 0; i < PosibleX.Length; i++)  
            {  
                x = current.x + PosibleX[i];  
                y = current.y + PosibleY[i];  
  
                // If reachable state is not yet visited and  
                // inside board, push that state into queue  
                if (_contexts.IsInside(new Vector2Int(x, y)) && !visit[x, y]) 
                {  
                    visit[x, y] = true;  
                    cells.Enqueue(new Cell(x, y, current.dist + 1, current));  
                }  
            }  
        }

        if (reachedCells.Count == 0) return RandomMove(startPos, targetPos);
        return NextMove(BestCell(reachedCells));
    }

    private Vector2Int RandomMove(Vector2Int startPos, Vector2Int targetPos)
    {
        Vector2Int nextPos = startPos;
        Vector2Int current = nextPos;
        float minDist = float.MaxValue;
        for (int i = 0; i < PosibleX.Length; i++)  
        {  
            current.x = startPos.x + PosibleX[i];  
            current.y = startPos.y + PosibleY[i];  

            if (_contexts.IsInside(current))
            {
                if (Vector2Int.Distance(current, targetPos) < minDist)
                {
                    minDist = Vector2Int.Distance(current, targetPos);
                    nextPos = current;
                }
            }  
        }

        return nextPos;
    }

    private Cell BestCell(List<Cell> reachedCells)
    {
        Cell bestCell = reachedCells[0];
        for (int i = 1; i < reachedCells.Count; i++)
        {
            if (reachedCells[i].dist < bestCell.dist)
                bestCell = reachedCells[i];
        }
        return bestCell;
    }

    private Vector2Int NextMove(Cell cell)
    {
        List<Cell> path = new List<Cell>();
        while (cell.parent != null)
        {
            path.Add(cell);
            cell = cell.parent;
        }
        path.Reverse();
        return new Vector2Int(path[0].x, path[0].y);
    }

    private class Cell
    {
        public Cell parent;
        public int x, y, dist;

        public Cell(int x, int y, int dist, Cell parent = null)
        {
            this.x = x;
            this.y = y;
            this.dist = dist;
            this.parent = parent;
        }
    }
}