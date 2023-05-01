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

  private bool isOnLadder = false;
  private float maxXVelocity = 300;
  public Vector2 FacingDirection = new Vector2(0, 0);
  public bool HasVortexGun = Globals.Debug;

  public override void _Process(double deltaTime) {
    UpdateCamera();
    FaceCorrectDirection();

    if (!IsFrozen) {
      ProcessKeyboardInput();
      CheckForDialog();
    }
  }

  public void ShowOverheadText(string text) {
    Nodes.OverheadText_Text.Text = text;
    Nodes.OverheadText_Text.VisibleRatio = 0;
    Nodes.OverheadText_AnimationPlayer.Play("PlayText");
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

    if (name == DialogTriggerName.CantMakeIt && HasVortexGun) {
      return;
    }

    if (Globals.Debug) {
      return;
    }

    DialogLock = true;

    await Root.Instance.Nodes.StaticCanvasLayer.Nodes.Dialog.RunDialog(name);

    DialogLock = false;
  }

  private void UpdateCamera() {
    var camera = Root.Instance.Nodes.Camera2D;

    camera.Position = new Vector2(
      Position.X + FacingDirection.X * 300,
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
    if (IsOnFloor() || isOnLadder) {
      if (Input.IsActionJustPressed("jump")) {
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
    if (!Input.IsActionPressed("jump") && Velocity.Y < 0) {
      Velocity = new Vector2(Velocity.X, 0.0f);
    }

    if (
      !Input.IsActionPressed("right") &&
      !Input.IsActionPressed("left")
    ) {
      Velocity = new Vector2(Velocity.X * 0.92f, Velocity.Y);
    }

    // check for ladders.
    var spaceState = GetWorld2D().DirectSpaceState;

    var ladderIntersection1 = spaceState.IntersectPoint(new PhysicsPointQueryParameters2D {
      CollisionMask = (uint)Globals.LayerNumbers[LayerMask.Ladder],
      CollideWithBodies = true,
      CollideWithAreas = true,
      Position = GlobalPosition + new Vector2(8, 0),
    });
    var ladderIntersection2 = spaceState.IntersectPoint(new PhysicsPointQueryParameters2D {
      CollisionMask = (uint)Globals.LayerNumbers[LayerMask.Ladder],
      CollideWithBodies = true,
      CollideWithAreas = true,
      Position = GlobalPosition - new Vector2(24, 0),
    });

    var touchingLadder = (ladderIntersection1.Count > 0) || (ladderIntersection2.Count > 0);

    if (touchingLadder) {
      // Get on a ladder if you press up / down
      if (!isOnLadder) {
        isOnLadder = Input.IsActionPressed("up") || Input.IsActionPressed("down");
      }

      // Get off ladder if you jump.
      if (isOnLadder) {
        if (Input.IsActionJustPressed("jump")) {
          isOnLadder = false;
        }
      }

      if (isOnLadder) {
        Velocity = new Vector2(Velocity.X,
          Input.IsActionPressed("down") ? 300 : Input.IsActionPressed("up") ? -300 : 0
        );
      }
    } else {
      isOnLadder = false;
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

    var randomMessages = new List<string> {
      "Robo-Delivery-Unit 3000: Online.",
      "Ow!",
      "I'm okay!",
      "Let's try again!",
      "We can do it if we try!",
      "Ouchie!",
      "Rebooted and ready to go!",
    };

    ShowOverheadText(
      randomMessages[(int)(GD.Randi() % randomMessages.Count)]
    );

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

  public void PickupItem(ItemType type) {
    if (type == ItemType.VortexGun) {
      HasVortexGun = true;

      var _ = TriggerDialog(DialogTriggerName.GetVortexGun);
    }
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
