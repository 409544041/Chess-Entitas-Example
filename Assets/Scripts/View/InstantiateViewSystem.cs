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
        for (int i = 0; i < entities.Count; i++)
        {
            GameEntity entity = entities[i];
            GameObject prefab = entity.asset.value;
            Vector2Int positionValue = entity.position.value;
            Vector3 position = new Vector3(positionValue.x, entity.isRevertY ? -positionValue.y : positionValue.y);
            IView view = Object.Instantiate(prefab, position, Quaternion.identity).GetComponent<IView>();
            view.Link(entity);
            entity.AddView(view);
        }
    }
}
