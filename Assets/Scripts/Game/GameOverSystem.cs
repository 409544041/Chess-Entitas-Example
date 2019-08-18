using System.Collections.Generic;
using Entitas;

public class GameOverSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    
    public GameOverSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            bool isGameOver = _contexts.game.playerEntity.position.value.Equals(
                              _contexts.game.enemyEntity.position.value);
            if (isGameOver)
            {
                _contexts.game.playingEntity.ReplacePlaying(false);
            }
        }
    }
}
