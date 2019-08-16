public sealed class GameSytems : Feature
{
    public GameSytems(Contexts contexts)
    {
        Add(new InputSystem(contexts));
        Add(new InputProcessSystem(contexts));
    }
}
