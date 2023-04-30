using Godot;
using System;
using static Utils;

public partial class VortexGun : Node2D {
  public override void _Ready() {
  }

  public override void _Process(double delta) {
    Nodes.Aim.GlobalPosition = Root.Instance.Nodes.Blub.GlobalPosition;
  }
}
