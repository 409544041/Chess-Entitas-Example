using UnityEngine;

[CreateAssetMenu]
public class GameConfigScriptable : ScriptableObject, IGameConfig
{
    [SerializeField] private Vector2Int _boardSize = new Vector2Int(8, 8);
    [SerializeField] private Vector2Int _pawnStartPos = new Vector2Int(0, 0); 
    [SerializeField] private Vector2Int _knightStartPos = new Vector2Int(7, 7);
    [SerializeField] private GameObject _pawnGO;
    [SerializeField] private GameObject _knightGO;
    [SerializeField] private float _knightMoveDelay = 2f;
    [SerializeField] private float _startGameAnimDelay = 1f;
    [SerializeField] private float _endGameAnimDelay = 1f;
    [SerializeField] private bool _revertY = true;

    public Vector2Int PawnStartPos
    {
        get { return _pawnStartPos; }
        set { _pawnStartPos = value; }
    }

    public Vector2Int KnightStartPos => _knightStartPos;
    public Vector2Int BoardSize => _boardSize;
    public GameObject PawnGO => _pawnGO;
    public GameObject KnightGO => _knightGO;
    public float KnightMoveDelay => _knightMoveDelay;
    public float StartGameAnimDelay => _startGameAnimDelay;
    public float EndGameAnimDelay => _endGameAnimDelay;
    public bool RevertY => _revertY;
}
