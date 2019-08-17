public sealed class GameSytems : Feature
{
    private Contexts _contexts;
    
    public GameSytems(Contexts contexts)
    {
        _contexts = contexts;
        // Init
        Add(new InstantiateViewSystem(contexts));
        Add(new InstantiatePlayerSystem(contexts));
        
        // Input
        Add(new InputSystem(contexts));
        Add(new InputProcessSystem(contexts));
    }
}
