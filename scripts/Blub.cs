using Godot;

public partial class Blub : CharacterBody2D {
  public override void _Ready() {
  }

  public override void _Process(double delta) {
    // move via arrow keys
    var move = new Vector2();

    if (Input.IsActionPressed("ui_right")) {
      move.X += 1;
    }

    if (Input.IsActionPressed("ui_left")) {
      move.X -= 1;
    }

    if (Input.IsActionPressed("ui_down")) {
      move.Y += 1;
    }

    if (Input.IsActionPressed("ui_up")) {
      move.Y -= 1;
    }

    Velocity = move.Normalized() * 300;

    MoveAndSlide();

    CheckForTilemapUpdates();
  }

  private void CheckForTilemapUpdates() {
    var mousePosition = GetViewport().GetMousePosition();
    var tilePosition = Root.Instance.Nodes.TileMap.LocalToMap(Position);
    var r = Root.Instance.Nodes;

    var sourceId = r.TileMap.TileSet.GetSourceId(0);
    r.TileMap.SetCell(
      0,
      tilePosition,
      sourceId,
      new Vector2I(2, 0)
    );
  }
}
