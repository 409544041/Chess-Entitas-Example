using System.Collections.Generic;
using Entitas;
using UnityEngine;

// Move enemy after each time delay
public class EnemyMoveSystem : IInitializeSystem, IExecuteSystem
{
    private Contexts _contexts;
    private float _moveDelay;
    private float _timeStamp;

    public EnemyMoveSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _moveDelay = _contexts.config.gameConfig.value.KnightMoveDelay;
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
        Vector2Int playerPosition = _contexts.game.playerEntity.position.value;
        _contexts.game.enemyEntity.AddTargetPosition(playerPosition);
    }
}