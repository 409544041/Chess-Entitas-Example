using System.Collections.Generic;
using Entitas;
using UnityEngine;

// Move player when has input
public class PlayerMoveSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;

    public PlayerMoveSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }
    
    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Input);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInput && _contexts.game.isPlayer;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        InputEntity inputEntity = entities.SingleEntity();
        Vector2Int inputValue = inputEntity.input.value;
        GameEntity player = _contexts.game.playerEntity;
        if (player.isRevertY) inputValue.y = -inputValue.y;
        Vector2Int playerPos = player.position.value;
        Vector2Int newPos = playerPos + inputValue;
        if (_contexts.IsInside(newPos)) 
            player.ReplacePosition(newPos);
        inputEntity.Destroy();
    }
}
