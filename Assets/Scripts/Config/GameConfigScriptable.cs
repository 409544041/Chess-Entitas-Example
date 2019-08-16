using UnityEngine;

[CreateAssetMenu]
public class GameConfigScriptable : ScriptableObject, IGameConfig
{
    [SerializeField] private Vector2Int _pawnStartPos = new Vector2Int(0, 0); 
    [SerializeField] Vector2Int _knightStartPos = new Vector2Int(7, 7);

    public Vector2Int PawnStartPos => _pawnStartPos;
    public Vector2Int KnightStartPos => _knightStartPos;
}
