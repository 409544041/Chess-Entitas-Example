using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameOverSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private IGroup<GameEntity> _postionEnemiesGroup;
    
    public GameOverSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _postionEnemiesGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Position));
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
        Vector2Int playerPosition = _contexts.game.playerEntity.position.value;
        foreach (var enemy in _postionEnemiesGroup)
        {
            bool isGameOver = playerPosition.Equals(enemy.position.value);
            if (isGameOver)
            {
                _contexts.game.isPlaying = false;
                LeanTween.value(0, 0, _contexts.config.gameConfig.value.EndGameAnimDelay).setOnComplete(() =>
                {
                    _contexts.ui.ReplaceHomeLabelActive(true);
                });
            }
        }
    }
}
