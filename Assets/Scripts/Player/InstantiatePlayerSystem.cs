using Entitas;
using UnityEngine;

public class InstantiatePlayerSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InstantiatePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Initialize()
    {
        GameEntity player = _contexts.game.CreateEntity();
        player.isPlayer = true;
        player.isRevertY = _contexts.config.gameConfig.value.RevertY;
        player.AddPosition(_contexts.config.gameConfig.value.PawnStartPos);
        player.AddAsset(_contexts.config.gameConfig.value.PawnGO);
    }
}
