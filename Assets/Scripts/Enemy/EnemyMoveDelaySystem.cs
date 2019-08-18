using Entitas;
using UnityEngine;

// Move enemy after each time delay
public class EnemyMoveDelaySystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _delayEnemiesGroup;
    
    private float _moveDelay;

    public EnemyMoveDelaySystem(Contexts contexts)
    {
        _contexts = contexts;
        _delayEnemiesGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Timer, GameMatcher.Delay));
    }

    public void Execute()
    {
        foreach (var entity in _delayEnemiesGroup)
        {
            if (Time.time >= entity.timer.value)
            {
                entity.ReplaceTimer(entity.timer.value + entity.delay.value);
                Move(entity);
            }  
        }
    }

    private void Move(GameEntity entity)
    {
        Vector2Int playerPosition = _contexts.game.playerEntity.position.value;
        entity.AddTargetPosition(playerPosition);
    }
}