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
        GameEntity enemy = _contexts.game.CreateEntity();
        enemy.isEnemy = true;
        enemy.isRevertY = _contexts.config.gameConfig.value.RevertY;
        enemy.AddPosition(_contexts.config.gameConfig.value.KnightStartPos);
        enemy.AddAsset(_contexts.config.gameConfig.value.KnightGO);
    }
}
