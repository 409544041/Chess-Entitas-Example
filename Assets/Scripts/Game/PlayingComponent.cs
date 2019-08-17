﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game][Unique][Event(EventTarget.Any)]
public class PlayingComponent : IComponent
{
    public bool value;
}
