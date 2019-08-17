using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InputProcessSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;

    public InputProcessSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }
    
    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Input);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInput;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        InputEntity inputEntity = entities.SingleEntity();
        Vector2Int inputValue = inputEntity.input.value;
        if (_contexts.config.gameConfig.value.RevertY) inputValue.y = -inputValue.y;
        Vector2Int playerPos = _contexts.game.playerEntity.position.value;
        Vector2Int newPos = playerPos + inputValue;
        if(_contexts.IsBound(newPos)) _contexts.game.playerEntity.ReplacePosition(newPos);
        inputEntity.Destroy();
    }
}
