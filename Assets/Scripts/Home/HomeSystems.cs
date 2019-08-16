public class HomeSystems : Feature
{
    public HomeSystems(Contexts contexts)
    {
        // Events
        Add(new GameEventSystems(contexts));
    }
}
