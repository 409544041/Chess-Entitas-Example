using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeLabelController : MonoBehaviour
{
    [SerializeField] private Button _btnStart;
    [SerializeField] private TMP_Dropdown _dropdownX;
    [SerializeField] private TMP_Dropdown _dropdownY;
    private Contexts _contexts;

    private void Start()
    {
        _btnStart.onClick.AddListener(Play);
        _contexts = Contexts.sharedInstance;
    }

    private void Play()
    {
        Vector2Int pawnPos = new Vector2Int(_dropdownX.value, _dropdownY.value);
        IGameConfig config = _contexts.config.gameConfig.value;
        config.PawnStartPos = pawnPos;
        _contexts.ui.ReplaceHomeLabelActive(false);
        LeanTween.value(0, 0, config.StartGameAnimDelay).setOnComplete(() => _contexts.game.isPlaying = true);
    }
}