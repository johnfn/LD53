using Godot;
using System;
using System.Collections.Generic;
using static Utils;

public partial class Mailbox : Node2D {
  public bool PortalExists = false;
  public Vector2 GlobalPortalLocation;
  public Rect2 SourceRect;
  public Rect2 DestRect;
  public int PortalSize = 3;

  public override void _Process(double delta) {
    var fakeBlub = Root.Instance.Nodes.FakeBlub;
    fakeBlub.Modulate = new Color(1, 1, 1, 0.3f);

    if (PortalExists) {
      var portalDelta = GlobalPosition - GlobalPortalLocation;
      var player = Root.Instance.Nodes.Blub;
      var playerRect = new Rect2(player.GlobalPosition, new Vector2(16, 16));

      if (playerRect.Intersects(SourceRect)) {
        fakeBlub.GlobalPosition = Root.Instance.Nodes.Blub.GlobalPosition - portalDelta;
        fakeBlub.Visible = true;

        if (Input.IsActionJustPressed("swap")) {
          Root.Instance.Nodes.Blub.GlobalPosition = Root.Instance.Nodes.Blub.GlobalPosition - portalDelta;
        }
      } else if (playerRect.Intersects(DestRect)) {
        fakeBlub.GlobalPosition = Root.Instance.Nodes.Blub.GlobalPosition + portalDelta;
        fakeBlub.Visible = true;

        if (Input.IsActionJustPressed("swap")) {
          Root.Instance.Nodes.Blub.GlobalPosition = Root.Instance.Nodes.Blub.GlobalPosition + portalDelta;
        }
      } else {
        fakeBlub.Visible = false;
      }
    }
  }

  List<Rect2> sourceRects = new();
  List<Rect2> destRects = new();

  public void CreatePortalAt(Vector2 globalPosition) {
    PortalExists = true;

    GlobalPortalLocation = globalPosition;
    var portalLocation = globalPosition;
    var sourceTileMap = Root.Instance.Nodes.TileMap;
    var sourceCenter = sourceTileMap.LocalToMap(GlobalPosition);

    var destTileMap = Root.Instance.Nodes.DarkWorld;
    var destCenter = destTileMap.LocalToMap(portalLocation);

    SourceRect = new Rect2(GlobalPosition - new Vector2(PortalSize, PortalSize) * 32, new Vector2(PortalSize * 2, PortalSize * 2) * 32);
    DestRect = new Rect2(portalLocation - new Vector2(PortalSize, PortalSize) * 32, new Vector2(PortalSize * 2, PortalSize * 2) * 32);

    // Clear previous state.
    destTileMap.Clear();
    destRects.Clear();
    sourceRects.Clear();

    for (var i = -PortalSize; i < PortalSize; i++) {
      for (var j = -PortalSize; j < PortalSize; j++) {
        var sourceLocation = sourceCenter + new Vector2I(i, j);
        var destLocation = destCenter + new Vector2I(i, j);
        var sourceTile = sourceTileMap.GetCellTileData(0, sourceLocation);

        destTileMap.SetCell(
          0,
          destLocation,
          // sourceTileMap.GetCellSourceId(0, sourceLocation),
          0, // TODO... lol. or maybe not. it works well enough.
          sourceTileMap.GetCellAtlasCoords(0, sourceLocation)
        );

        sourceRects.Add(
          new Rect2(
            sourceTileMap.MapToLocal(sourceLocation) - GlobalPosition,
            new Vector2(32, 32)
          )
        );

        destRects.Add(
          new Rect2(
            destTileMap.MapToLocal(destLocation) - GlobalPosition,
            new Vector2(32, 32)
          )
        );
      }
    }

    QueueRedraw();
  }

  public override void _Draw() {
    foreach (var rect in sourceRects) {
      DrawRect(rect, new Color(1, 0, 0, 0.1f));
    }

    foreach (var rect in destRects) {
      DrawRect(rect, new Color(0, 0, 1, 0.1f));
    }
  }
}
