using Godot;
using System;
using static Utils;

public partial class Cannon : Node2D {
  double _time = 0;
  public PackedScene CannonBallScene = GD.Load<PackedScene>("res://cannonball.tscn");

  [Export]
  public Vector2 Facing = new Vector2(-1, 0);

  public override void _Ready() {

  }

  public override void _Process(double delta) {
    _time += delta;

    if (_time > 1) {
      _time = 0;

      var cannonBall = (CannonBall)CannonBallScene.Instantiate();
      cannonBall.GlobalPosition = GlobalPosition + Facing * 60;
      cannonBall.Rotation = Rotation;
      cannonBall.Facing = Facing;

      GetParent().AddChild(cannonBall);
    }
  }
}
