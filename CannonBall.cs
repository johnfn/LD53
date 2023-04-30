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
  }

  public void Explode() {
    QueueFree();
  }

  public override void _Process(double delta) {
    // Velocity = Facing * 100 * (float)delta;

    // var collision = MoveAndCollide();
    // if (collision != null) {
    //   var enemy = collision.Collider as Enemy;
    //   if (enemy != null) {
    //     enemy.QueueFree();
    //     QueueFree();
    //   }
    // }
  }
}
