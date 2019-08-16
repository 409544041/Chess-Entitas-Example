using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeLabelController : MonoBehaviour
{
    [SerializeField] private Button _btnStart;
    [SerializeField] private TMP_Dropdown _dropdownX;
    [SerializeField] private TMP_Dropdown _dropdownY;
    private GameEntity _active;

    private void Start()
    {
        _btnStart.onClick.AddListener(Play);
    }

    private void Play()
    {
        Vector2Int pawnPos = new Vector2Int(_dropdownX.value, _dropdownY.value);
        Debug.Log(pawnPos);
        Contexts.sharedInstance.game.ReplaceActive(false);
    }
}
