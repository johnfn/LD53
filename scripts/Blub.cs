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

  public override void _Ready() {
  }

  public override void _Process(double deltaTime) {
    UpdateCamera();
    FaceCorrectDirection();

    if (!IsFrozen) {
      ProcessKeyboardInput();
      CheckForDialog();
    }
  }

  private void FaceCorrectDirection() {
    var newFacingDirection = FacingDirection;

    if (Input.IsActionPressed("right")) {
      newFacingDirection.X = 1;
    } else if (Input.IsActionPressed("left")) {
      newFacingDirection.X = -1;
    }

    if (Input.IsActionPressed("down")) {
      newFacingDirection.Y = 1;
    } else if (Input.IsActionPressed("up")) {
      newFacingDirection.Y = -1;
    }

    FacingDirection = newFacingDirection;

    Nodes.Graphic.FlipH = FacingDirection.X < 0;
    Nodes.GraphicAlt.FlipH = FacingDirection.X < 0;
  }

  // private void LookForCheckpoint() {
  //   if (IsOnFloor()) {
  //     var positions = new List<Vector2> {
  //       GlobalPosition + new Vector2(-20, 15),
  //       GlobalPosition + new Vector2(0, 15),
  //       GlobalPosition + new Vector2(20, 15),
  //     };
  //     var collisions = 0;

  //     foreach (var position in positions) {
  //       var collision = PhysicsServer2D.SpaceGetDirectState(GetWorld2D().Space).IntersectPoint(
  //         new PhysicsPointQueryParameters2D {
  //           Position = position,
  //           CollideWithBodies = true,
  //           CollideWithAreas = true,
  //           CollisionMask = 1,
  //         });

  //       if (collision.Count > 0) {
  //         collisions += 1;
  //       }
  //     }

  //     if (collisions == 3) {
  //       LastSafeSpot = GlobalPosition;
  //     }
  //   }
  // }

  private void CheckForDialog() {
    var allAreas = Nodes.InteractionArea.GetOverlappingAreas();

    if (allAreas.Count > 0) {
      foreach (var area in allAreas) {
        var parent = area.GetParent();

        if (parent is DialogTrigger trigger) {
          if (trigger.TriggerType == DialogTriggerType.Automatic) {
            if (IsOnFloor()) {
              trigger.QueueFree();

              var _ = TriggerDialog(trigger.TriggerName);
            }
          } else if (trigger.TriggerType == DialogTriggerType.RequiresInteraction) {
            if (Input.IsActionJustPressed("interact")) {
              trigger.QueueFree();

              var _ = TriggerDialog(trigger.TriggerName);
            }
          }
        }
      }
    }
  }

  public async Task TriggerDialog(DialogTriggerName name) {
    if (IsFrozen) {
      return;
    }

    DialogLock = true;

    await Root.Instance.Nodes.StaticCanvasLayer.Nodes.Dialog.RunDialog(name);

    DialogLock = false;
  }

  private void UpdateCamera() {
    var camera = Root.Instance.Nodes.Camera2D;

    camera.Position = new Vector2(
      Position.X + FacingDirection.X * 100,
      Position.Y + FacingDirection.Y * 100
    ).Floor();
  }

  private void ProcessKeyboardInput() {
    // move via arrow keys
    var delta = new Vector2();

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
        delta.Y = -3;
      } else {
        delta.Y = 10;
      }
    }

    // if we're on the ground, we can jump
    if (IsOnFloor()) {
      if (Input.IsActionJustPressed("up")) {
        delta.Y = -730;
      }
    }

    Velocity += delta;

    if (Velocity.X > maxXVelocity) {
      Velocity = new Vector2(maxXVelocity, Velocity.Y);
    }

    if (Velocity.X < -maxXVelocity) {
      Velocity = new Vector2(-maxXVelocity, Velocity.Y);
    }

    // Instantly start falling if we're not holding the jump btn.
    if (!Input.IsActionPressed("up") && Velocity.Y < 0) {
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

    if (SaveStation.ActiveSaveStation != null) {
      GlobalPosition = SaveStation.ActiveSaveStation.GlobalPosition + new Vector2(32, -32);
    }

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
