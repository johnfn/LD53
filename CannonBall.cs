using Godot;
using System;
using static Utils;

public partial class CannonBall : RigidBody2D {
  public Vector2 Facing = new Vector2(1, 0);

  public override void _Ready() {
    GravityScale = 0;
    ContactMonitor = true;
    MaxContactsReported = 32;

    ApplyImpulse(Facing * 200);

    BodyEntered += (body) => {
      Explode();

      if (body is Blub b) {
        b.DieAndRespawn();
      }
    };

    Nodes.VisibleOnScreenNotifier2D.VisibilityChanged += () => {
      if (!Nodes.VisibleOnScreenNotifier2D.IsOnScreen()) {
        QueueFree();
      }
    };
  }

  public void Explode() {
    QueueFree();
  }
}
