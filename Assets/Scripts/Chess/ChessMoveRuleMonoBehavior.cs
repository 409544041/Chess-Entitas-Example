using Entitas;
using UnityEngine;

public class ChessMoveRuleMonoBehavior : BaseComponentMonoBehaviour
{
    [SerializeField] int[] _reachablePosX;
    [SerializeField] int[] _reachablePosY;
    
    public override IComponent Component
    {
        get 
        { 
            return new ChessMoveRuleComponent()
            {
                reachablePosX = _reachablePosX,
                reachablePosY = _reachablePosY
            }; 
        }
    }
}
