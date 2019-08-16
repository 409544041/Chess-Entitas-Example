using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Config, Unique, ComponentName("GameConfig")]
public interface IGameConfig
{
    Vector2Int PawnStartPos { get; }
    Vector2Int KnightStartPos { get; }
}
