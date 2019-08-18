using UnityEngine;

public class BoardController : MonoBehaviour, IAnyPlayingListener
{
    [SerializeField] private GameObject _boardGO;
    private Contexts _contexts;
    
    private void Start()
    {
        _contexts = Contexts.sharedInstance;
        var listener = _contexts.game.CreateEntity();
        listener.AddAnyPlayingListener(this);
    }

    public void OnAnyPlaying(GameEntity entity)
    {
        if (entity.isPlaying)
        {
            IGameConfig config = _contexts.config.gameConfig.value;
            float posY = config.BoardSize.y / 2f - 0.5f;
            Vector3 pos = transform.localPosition;
            pos.x = config.BoardSize.x / 2f - 0.5f;
            pos.y = config.RevertY ? -posY : posY;
            transform.localPosition = pos;
            _boardGO.SetActive(true);
        }
    }
}
