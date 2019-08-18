using System.Collections.Generic;
using Entitas;
using UnityEngine;

// Find the best move with knight rules
public class KnightPathFindingSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public KnightPathFindingSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.TargetPosition));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasTargetPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            GameEntity entity = entities[i];
            entity.ReplacePosition(FindPath(entity.position.value, entity.targetPosition.value));
            entity.RemoveTargetPosition();
        }
    }
    
    private Vector2Int FindPath(Vector2Int startPos, Vector2Int targetPos)
    {
        Cell current;
        // Queue for store seaching cells
        Queue<Cell> cells = new Queue<Cell>();
        // Enqueue starting position with 0 distance
        cells.Enqueue(new Cell(startPos.x, startPos.y, 0));
        // Create visit array scale with board size to check state of all cells
        Vector2Int boardSize = _contexts.config.gameConfig.value.BoardSize;
        bool[,] visit = new bool[boardSize.x, boardSize.y];
        // Mark starting cell is visited
        visit[startPos.x, startPos.y] = true;
        // Storing all path is reached
        List<Cell> reachCells = new List<Cell>();
        // Loop for all poisible cells
        while (cells.Count > 0)
        {
            // Take a cell
            current = cells.Dequeue();
  
            // If current cell is equal to target cell
            // Add to reach list
            if (current.x == targetPos.x && current.y == targetPos.y)
            {
                reachCells.Add(current);
            }

            // Get all reachable position from current postion
            Vector2Int[] reachablePosition = GetKnightReachablePosition(current.x, current.y);

            // Loop for all reachable position
            for (int i = 0; i < reachablePosition.Length; i++)
            {
                int x = reachablePosition[i].x;
                int y = reachablePosition[i].y;
                // If reachable position is not yet visited
                // Create cell to push that into queue  
                if (!visit[x, y]) 
                {  
                    visit[x, y] = true;  
                    cells.Enqueue(new Cell(x, y, current.dist + 1, current));  
                }  
            }
        }

        // If empty reachable path
        // Return random position to move
        if (reachCells.Count == 0) 
            return RandomMove(startPos, targetPos);
        // Return next position with minimum distance
        return RetraceNextPosition(MinimunDistanceCell(reachCells));
    }

    private Vector2Int[] GetKnightReachablePosition(int posX, int posY)
    {
        List<Vector2Int> reachableList = new List<Vector2Int>();
        // Loop for all knight reachable position  
        for (int i = 0; i < KnightReachableConstant.ReachableX.Length; i++)  
        {  
            int x = posX + KnightReachableConstant.ReachableX[i];  
            int y = posY + KnightReachableConstant.ReachableY[i];  
            // If reachable position is inside the board
            // Add to reachable list
            if (_contexts.IsInside(x, y))
            {
                reachableList.Add(new Vector2Int(x, y));
            }  
        }

        return reachableList.ToArray();
    }

    private Vector2Int RandomMove(Vector2Int startPos, Vector2Int targetPos)
    {
        Vector2Int nextPos = startPos;
        Vector2Int current = nextPos;
        float minDist = float.MaxValue;
        // Get all reachable position from starting position
        Vector2Int[] reachablePosition = GetKnightReachablePosition(startPos.x, startPos.y);

        // Loop for all reachable position
        for (int i = 0; i < reachablePosition.Length; i++)
        {
            current = reachablePosition[i];
            // If distance from current to target pos is less than min distance
            // Add current postion to next position
            if (Vector2Int.Distance(current, targetPos) < minDist)
            {
                minDist = Vector2Int.Distance(current, targetPos);
                nextPos = current;
            }
        }

        return nextPos;
    }

    private Cell MinimunDistanceCell(List<Cell> reachCells)
    {
        Cell bestCell = reachCells[0];
        for (int i = 1; i < reachCells.Count; i++)
        {
            if (reachCells[i].dist < bestCell.dist)
                bestCell = reachCells[i];
        }
        return bestCell;
    }

    private Vector2Int RetraceNextPosition(Cell cell)
    {
        Stack<Cell> path = new Stack<Cell>();
        while (cell.parent != null)
        {
            path.Push(cell);
            cell = cell.parent;
        }

        Cell nextCell = path.Pop();
        return new Vector2Int(nextCell.x, nextCell.y);
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
