using System.Collections.Generic;
using Entitas;

public class GameStateSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public GameStateSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Playing);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPlaying;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        GameEntity entity = entities.SingleEntity();
        
    }
}
