using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Config, Unique, ComponentName("GameConfig")]
public interface IGameConfig
{
    Vector2Int BoardSize { get; }
    Vector2Int PawnStartPos { get; set; }
    Vector2Int KnightStartPos { get; }
    GameObject PawnGO { get; }
    GameObject KnightGO { get; }
    float KnightMoveDelay { get; }
    float StartGameAnimDelay { get; }
    float EndGameAnimDelay { get; }
    bool RevertY { get; }
}
