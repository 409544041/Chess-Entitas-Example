using Entitas;
using UnityEngine;

public class InstantiateEnemySystem : IInitializeSystem
{
    private Contexts _contexts;

    public InstantiateEnemySystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Initialize()
    {
        IGameConfig config = _contexts.config.gameConfig.value;
        if (!_contexts.game.isEnemy)
        {
            GameEntity enemy = _contexts.game.CreateEntity();
            enemy.isEnemy = true;
            enemy.isRevertY = config.RevertY;
            enemy.AddPosition(config.KnightStartPos);
            enemy.AddAsset(config.KnightGO);   
        }
        else
        {
            _contexts.game.enemyEntity.ReplacePosition(config.KnightStartPos);
        }
    }
}
