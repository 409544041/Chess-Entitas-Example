public sealed class GameSytems : Feature
{
    public GameSytems(Contexts contexts)
    {
        // Events
        Add(new GameEventSystems(contexts));
        
        // Input
        Add(new InputSystem(contexts));
        Add(new InputProcessSystem(contexts));
    }
}
