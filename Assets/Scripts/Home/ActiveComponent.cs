using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game][Unique][Event(EventTarget.Any)]
public class ActiveComponent : IComponent
{
    public bool value;
}
