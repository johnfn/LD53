using System.Collections.Generic;
using System.Threading.Tasks;
using Godot;
using static Utils;

public partial class Blub : CharacterBody2D {
  public static bool IsFrozen {
    get {
      return DialogLock || DeathLock;
    }
  }
  public static bool DialogLock = false;
  public static bool DeathLock = false;

  private float maxXVelocity = 300;
  public Vector2 FacingDirection = new Vector2(0, 0);
  public Vector2 LastSafeSpot = new Vector2(0, 0);

  public override void _Ready() {
  }

  public override void _Process(double deltaTime) {
    UpdateCamera();

    if (!IsFrozen) {
      LookForCheckpoint();
      ProcessKeyboardInput();
      CheckForDialog();
    }
  }

  private void LookForCheckpoint() {
    if (IsOnFloor()) {
      var positions = new List<Vector2> {
        GlobalPosition + new Vector2(-20, 15),
        GlobalPosition + new Vector2(0, 15),
        GlobalPosition + new Vector2(20, 15),
      };
      var collisions = 0;

      foreach (var position in positions) {
        var collision = PhysicsServer2D.SpaceGetDirectState(GetWorld2D().Space).IntersectPoint(
          new PhysicsPointQueryParameters2D {
            Position = position,
            CollideWithBodies = true,
            CollideWithAreas = true,
            CollisionMask = 1,
          });

        if (collision.Count > 0) {
          collisions += 1;
        }
      }

      if (collisions == 3) {
        LastSafeSpot = GlobalPosition;
      }
    }
  }

  private void CheckForDialog() {
    var allAreas = Nodes.InteractionArea.GetOverlappingAreas();

    if (allAreas.Count > 0) {
      foreach (var area in allAreas) {
        var parent = area.GetParent();

        if (parent is DialogTrigger trigger) {
          if (trigger.TriggerType == DialogTriggerType.Automatic) {
            if (IsOnFloor()) {
              var _ = TriggerDialog(trigger, trigger.TriggerName);
            }
          } else if (trigger.TriggerType == DialogTriggerType.RequiresInteraction) {
            if (Input.IsActionJustPressed("interact")) {
              var _ = TriggerDialog(trigger, trigger.TriggerName);
            }
          }
        }
      }
    }
  }

  private async Task TriggerDialog(DialogTrigger trigger, DialogTriggerName name) {
    if (IsFrozen) {
      return;
    }

    DialogLock = true;

    trigger.QueueFree();

    await Root.Instance.Nodes.StaticCanvasLayer_Dialog.RunDialog(name);

    DialogLock = false;
  }

  private void UpdateCamera() {
    var camera = Root.Instance.Nodes.Camera2D;

    camera.Position = new Vector2(
      Position.X + FacingDirection.X * 100,
      Position.Y + FacingDirection.Y * 100
    );
  }

  private void ProcessKeyboardInput() {
    // move via arrow keys
    var delta = new Vector2();

    FacingDirection = new Vector2(
      (Input.IsActionPressed("right") ? 1 : 0) +
      (Input.IsActionPressed("left") ? -1 : 0),
      (Input.IsActionPressed("down") ? 1 : 0) +
      (Input.IsActionPressed("up") ? -1 : 0) +
      (IsOnFloor() && Input.IsActionPressed("jump") ? -1 : 0)
    );

    // ensure no component of facing direction is greater than 1
    if (FacingDirection.Length() > 1) {
      FacingDirection = FacingDirection.Normalized();
    }

    if (Input.IsActionPressed("right")) {
      delta.X += 60;
    }

    if (Input.IsActionPressed("left")) {
      delta.X -= 60;
    }

    delta.Y += 50.0f;

    if (delta.Y >= 10) {
      if (Velocity.Y > 200) {
        delta.Y = 3;
      } else {
        delta.Y = 10;
      }
    }

    // if we're on the ground, we can jump
    if (IsOnFloor()) {
      if (Input.IsActionJustPressed("jump")) {
        delta.Y = -600;
      }
    }


    Velocity += delta;

    if (Velocity.X > maxXVelocity) {
      Velocity = new Vector2(maxXVelocity, Velocity.Y);
    }

    if (Velocity.X < -maxXVelocity) {
      Velocity = new Vector2(-maxXVelocity, Velocity.Y);
    }

    if (!Input.IsActionPressed("jump") && Velocity.Y < 0) {
      Velocity = new Vector2(Velocity.X, 0.0f);
    }

    if (
      !Input.IsActionPressed("right") &&
      !Input.IsActionPressed("left")
    ) {
      Velocity = new Vector2(Velocity.X * 0.92f, Velocity.Y);
    }

    MoveAndSlide();

    var numCollisions = GetSlideCollisionCount();

    for (var i = 0; i < numCollisions; i++) {
      var collision = GetSlideCollision(i);
      var collider = collision.GetCollider();
      var position = collision.GetPosition();

      if (collider is TileMap tm) {
        var rid = collision.GetColliderRid();
        var layer = PhysicsServer2D.BodyGetCollisionLayer(rid);
        var mask = Globals.LayerMasks[layer];

        if (mask == LayerMask.Spikes) {
          DieAndRespawn();
        }
      }

      if (collider is CannonBall c) {
        c.Explode();
        DieAndRespawn();
      }
    }
  }

  public async void DieAndRespawn() {
    if (IsFrozen) {
      return;
    }

    DeathLock = true;

    for (var i = 0; i < 20; i++) {
      await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

      Scale += new Vector2(0.04f, 0.04f);
      Modulate = new Color(1, 1, 1, 1.0f - i * 0.05f);
    }

    Scale = new Vector2(1, 1);
    Modulate = new Color(1, 1, 1, 1);

    GlobalPosition = LastSafeSpot;

    DeathLock = false;

    for (var i = 0; i < 40; i++) {
      await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

      // do a flicker effect

      if (i % 8 < 4) {
        Modulate = new Color(0.2f, 1, 1, 0);
      } else {
        Modulate = new Color(1, 1, 1, 0.3f);
      }
    }

    Modulate = new Color(1, 1, 1, 1);
  }

  // private void CheckForTilemapUpdates() {
  //   var mousePosition = GetViewport().GetMousePosition();
  //   var tilePosition = Root.Instance.Nodes.TileMap.LocalToMap(Position);
  //   var r = Root.Instance.Nodes;

  //   // var sourceId = r.TileMap.TileSet.GetSourceId(0);
  //   // r.TileMap.SetCell(
  //   //   0,
  //   //   tilePosition,
  //   //   sourceId,
  //   //   new Vector2I(2, 0)
  //   // );
  // }
}
