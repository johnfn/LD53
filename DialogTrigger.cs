using Godot;
using System;
using static Utils;

public enum DialogTriggerType {
  Automatic,
  RequiresInteraction,
}

public enum DialogTriggerName {
  FirstInteraction,
  SecondInteraction,
  SaveStation,
  OhShootSpikes,
  OhShootCannon,
  FirstPortal,
  SecondPortal,
  CantMakeIt,
}

public partial class DialogTrigger : Node2D {
  [Export]
  public DialogTriggerType TriggerType = DialogTriggerType.Automatic;

  [Export]
  public DialogTriggerName TriggerName = DialogTriggerName.FirstInteraction;

  public bool HasBeenTriggered = false;

  public override void _Ready() {
  }

  public override void _Process(double delta) {
  }
}
