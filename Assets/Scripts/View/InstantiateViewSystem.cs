using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InstantiateViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public InstantiateViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsset && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            GameObject prefab = entity.asset.value;
            IView view = Object.Instantiate(prefab).GetComponent<IView>();
            view.Link(entity);
            entity.AddView(view);
        }
    }
}
