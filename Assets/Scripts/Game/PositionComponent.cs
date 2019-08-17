using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public class PositionComponent : IComponent
{
    public Vector2Int value;
}
