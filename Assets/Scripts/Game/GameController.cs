using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour, IAnyPlayingListener
{
    [SerializeField] private GameConfigScriptable _gameConfig;
    private Contexts _contexts;
    private Systems _systems;
    
    private void Start()
    {
        _contexts = Contexts.sharedInstance;
        _contexts.config.SetGameConfig(_gameConfig);
        _contexts.game.CreateEntity().AddAnyPlayingListener(this);
        _systems = new HomeSystems(_contexts);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    public void OnAnyPlaying(GameEntity entity, bool value)
    {
        if (value)
        {
            _systems.Add(new GameSytems(_contexts));
            _systems.Initialize();
        }
    }
}
