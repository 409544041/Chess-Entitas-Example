using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class ChessMoveRuleComponent : IComponent
{
    public int[] reachablePosX;
    public int[] reachablePosY;
}
