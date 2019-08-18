public class HomeSystems : Feature
{
    public HomeSystems(Contexts contexts)
    {
        // Events
        Add(new UiEventSystems(contexts));
        Add(new GameEventSystems(contexts));
    }
}
