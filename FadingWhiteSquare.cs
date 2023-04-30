using Godot;
using System;
using static Utils;

public partial class FadingWhiteSquare : Sprite2D {
  private double LifeSpan = 0.6;

  public override void _Process(double delta) {
    LifeSpan -= delta;

    if (LifeSpan <= 0) {
      QueueFree();
    } else {
      Modulate = new Color(1, 1, 1, (float)LifeSpan);
    }
  }
}
