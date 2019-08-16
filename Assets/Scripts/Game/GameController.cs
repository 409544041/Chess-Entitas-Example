using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameConfigScriptable _gameConfig;
    private Systems _systems;
    
    private void Start()
    {
        Contexts contexts = Contexts.sharedInstance;
        contexts.config.SetGameConfig(_gameConfig);
        _systems = new Feature("Systems")
            .Add(new GameSytems(contexts))
            .Add(new HomeSystems(contexts));
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}
