using Godot;
using System;
using static Utils;

public partial class Audio : Node2D {
  public static Audio Instance { get; private set; } = null!;

  public override void _Ready() {
    Instance = this;
  }
}
