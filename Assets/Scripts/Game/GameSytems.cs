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
        
        // Input
        Add(new InputSystem(contexts));
        Add(new InputProcessSystem(contexts));
        
        // State
        Add(new GameOverSystem(contexts));
    }

    public override void Execute()
    {
        if(_contexts.game.playingEntity.playing.value)
            base.Execute();
    }
}
