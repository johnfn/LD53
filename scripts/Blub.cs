using Godot;

public partial class Blub : CharacterBody2D {
  private float maxXVelocity = 300;
  public Vector2 FacingDirection = new Vector2(0, 0);
  public override void _Ready() {
  }

  public override void _Process(double deltaTime) {
    ProcessKeyboardInput();
    UpdateCamera();
    CheckForTilemapUpdates();
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

    if (
      !Input.IsActionPressed("right") &&
      !Input.IsActionPressed("left")
    ) {
      Velocity = new Vector2(Velocity.X * 0.92f, Velocity.Y);
    }

    MoveAndSlide();
  }

  private void CheckForTilemapUpdates() {
    var mousePosition = GetViewport().GetMousePosition();
    var tilePosition = Root.Instance.Nodes.TileMap.LocalToMap(Position);
    var r = Root.Instance.Nodes;

    // var sourceId = r.TileMap.TileSet.GetSourceId(0);
    // r.TileMap.SetCell(
    //   0,
    //   tilePosition,
    //   sourceId,
    //   new Vector2I(2, 0)
    // );
  }
}
