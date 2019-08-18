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
        IGameConfig config = _contexts.config.gameConfig.value;
        if (!_contexts.game.isPlayer)
        {
            GameEntity player = _contexts.game.CreateEntity();
            player.isPlayer = true;
            player.isPawn = true;
            player.isRevertY = config.RevertY;
            player.AddPosition(config.PawnStartPos);
            player.AddAsset(config.PawnGO);            
        }
        else
        {
            _contexts.game.playerEntity.ReplacePosition(config.PawnStartPos);
        }
    }
}
