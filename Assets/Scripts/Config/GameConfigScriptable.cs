using UnityEngine;

[CreateAssetMenu]
public class GameConfigScriptable : ScriptableObject, IGameConfig
{
    [SerializeField] private Vector2Int _boardSize = new Vector2Int(8, 8);
    [SerializeField] private Vector2Int _pawnStartPos = new Vector2Int(0, 0); 
    [SerializeField] private Vector2Int _knightStartPos = new Vector2Int(7, 7);
    [SerializeField] private GameObject _pawnGO;
    [SerializeField] private GameObject _knightGO;
    [SerializeField] private float _startDelay = 1f;

    public Vector2Int BoardSize => _boardSize;
    public Vector2Int PawnStartPos => _pawnStartPos;
    public Vector2Int KnightStartPos => _knightStartPos;
    public GameObject PawnGO => _pawnGO;
    public GameObject KnightGO => _knightGO;
    public float StartDelay => _startDelay;
}
