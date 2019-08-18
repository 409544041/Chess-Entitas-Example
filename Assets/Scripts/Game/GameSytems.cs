public sealed class GameSytems : Feature
{
    private Contexts _contexts;
    
    public GameSytems(Contexts contexts)
    {
        _contexts = contexts;
        // Init
        Add(new InstantiatePlayerSystem(contexts));
        Add(new InstantiateEnemySystem(contexts));
        Add(new InstantiateViewSystem(contexts));
        
        // Move
        Add(new PlayerMoveSystem(contexts));        
        Add(new EnemyMoveSystem(contexts));
        Add(new KnightPathFindingSystem(contexts));
        
        // Input
        Add(new InputSystem(contexts));
        
        // GameState
        Add(new GameOverSystem(contexts));
    }

    public override void Execute()
    {
        if(_contexts.game.isPlaying)
            base.Execute();
    }
}
