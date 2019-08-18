using Entitas;
using UnityEngine;

public class InstantiateEnemySystem : IInitializeSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _enemiesGroup;

    public InstantiateEnemySystem(Contexts contexts)
    {
        _contexts = contexts;
        _enemiesGroup = _contexts.game.GetGroup(GameMatcher.Enemy);
    }
    
    public void Initialize()
    {
        IGameConfig config = _contexts.config.gameConfig.value;
        if (_enemiesGroup.count == 0)
        {
            GameEntity enemy = _contexts.game.CreateEntity();
            enemy.isEnemy = true;
            enemy.isKnight = true;
            enemy.isRevertY = config.RevertY;
            enemy.AddPosition(config.KnightStartPos);
            enemy.AddDelay(config.KnightMoveDelay);
            enemy.AddTimer(Time.time + config.KnightMoveDelay);
            enemy.AddAsset(config.KnightGO);
        }
        else
        {
            foreach (var enemy in _enemiesGroup)
            {
                enemy.ReplacePosition(config.KnightStartPos);
                enemy.ReplaceTimer(Time.time + config.KnightMoveDelay);
            }
        }
    }
}
