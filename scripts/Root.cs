using Godot;

public partial class Root : Node2D {
  public static Root Instance { get; private set; } = null!;

  public override void _Ready() {
    Instance = this;

    var sourceId = Nodes.TileMap.TileSet.GetSourceId(0);

    this.Nodes.TileMap.SetCell(
      0,
      new Vector2I(0, 0),
      sourceId,
      new Vector2I(0, 0)
    );
  }

  public override void _Process(double delta) {
    var mousePosition = GetViewport().GetMousePosition();

    if (
      Nodes.TileMap.GetViewportRect().HasPoint(mousePosition)
    ) {
      var tilePosition = Nodes.TileMap.LocalToMap(mousePosition);

      // print(tilePosition.ToString());

      // var sourceId = Nodes.TileMap.TileSet.GetSourceId(0);

      // Nodes.TileMap.SetCell(
      //   0,
      //   tilePosition,
      //   sourceId,
      //   new Vector2I(0, 0)
      // );
    }
  }
}
