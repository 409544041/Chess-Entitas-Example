using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class KnightMoveRuleSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public KnightMoveRuleSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Knight));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isKnight && !entity.hasChessMoveRule;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            Debug.Log(entity);
            entity.AddChessMoveRule(ChessReachableConstant.KnightReachablePosX, ChessReachableConstant.KnightReachablePosY);
        }
    }
}
