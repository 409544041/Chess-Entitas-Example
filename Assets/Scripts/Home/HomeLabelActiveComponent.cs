using Entitas;
using Entitas.CodeGeneration.Attributes;

[Ui][Unique][Event(EventTarget.Self)]
public class HomeLabelActiveComponent : IComponent
{
    public bool value;
}
