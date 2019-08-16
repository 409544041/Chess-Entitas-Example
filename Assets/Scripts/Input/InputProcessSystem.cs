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
        InputComponent input = inputEntity.input;
        Debug.Log(input.value);
        inputEntity.Destroy();
    }
}
