public sealed class GameSytems : Feature
{
    private Contexts _contexts;
    
    public GameSytems(Contexts contexts)
    {
        _contexts = contexts;
        // Input
        Add(new InputSystem(contexts));
        Add(new InputProcessSystem(contexts));
    }

    public override void Execute()
    {
        if(_contexts.game.isPlaying)
            base.Execute();
    }
}
