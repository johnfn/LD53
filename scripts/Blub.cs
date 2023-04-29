using Godot;

public partial class Blub : CharacterBody2D {
  private float maxXVelocity = 300;
  public override void _Ready() {
  }

  public override void _Process(double deltaTime) {
    // move via arrow keys
    var delta = new Vector2();

    if (Input.IsActionPressed("right")) {
      delta.X += 60;
    }

    if (Input.IsActionPressed("left")) {
      delta.X -= 60;
    }

    delta.Y += 50.0f;

    if (delta.Y >= 10) {
      delta.Y = 10;
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

    if (Velocity.Y > 200) {
      Velocity = new Vector2(Velocity.X, 200);
    }

    if (
      !Input.IsActionPressed("right") &&
      !Input.IsActionPressed("left")
    ) {
      Velocity = new Vector2(Velocity.X * 0.92f, Velocity.Y);
    }

    MoveAndSlide();

    CheckForTilemapUpdates();
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
