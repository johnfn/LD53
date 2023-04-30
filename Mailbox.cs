using Godot;
using System;
using System.Collections.Generic;
using static Utils;

public partial class Mailbox : Node2D {
  public bool PortalExists = false;
  public Vector2 GlobalPortalLocation;
  public Rect2 SourceRect;
  public Rect2 DestRect;
  public static int PortalRadius = 3;

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

  public void ShowPortalPreviewAt(Vector2 globalPosition) {
    // Draw preview rectangle to preview tilemap.

    var sourceTileMap = Root.Instance.Nodes.TileMap;
    var previewTileMap = Root.Instance.Nodes.DarkWorldPreview;
    var portalRadius = Mailbox.PortalRadius;
    var sourceCenter = sourceTileMap.LocalToMap(GlobalPosition);

    previewTileMap.Clear();

    for (var i = -portalRadius; i < portalRadius; i++) {
      for (var j = -portalRadius; j < portalRadius; j++) {
        var sourceLocation = sourceCenter + new Vector2I(i, j);
        var destLocation = previewTileMap.LocalToMap(
          previewTileMap.ToLocal(globalPosition)
        ) + new Vector2I(i, j);
        var sourceTile = sourceTileMap.GetCellTileData(0, sourceLocation);

        previewTileMap.SetCell(
          0,
          destLocation,
          // sourceTileMap.GetCellSourceId(0, sourceLocation),
          2, //the all white tilemap
          sourceTileMap.GetCellAtlasCoords(0, sourceLocation),
          1 // no collision on these guys, theyre just previews
        );
      }
    }
  }

  List<Rect2> sourceRects = new();
  List<Rect2> destRects = new();
  List<Vector2I> previouslyClearedTiles = new();

  public async void CreatePortalAt(Vector2 globalPosition) {
    Nodes.AnimationPlayer.Play("PulseBorder");

    PortalExists = true;

    GlobalPortalLocation = globalPosition;
    var portalLocation = globalPosition;
    var sourceTileMap = Root.Instance.Nodes.TileMap;
    var sourceCenter = sourceTileMap.LocalToMap(GlobalPosition);

    var destTileMap = Root.Instance.Nodes.DarkWorld;
    var destCenter = destTileMap.LocalToMap(portalLocation);

    SourceRect = new Rect2(GlobalPosition - new Vector2(PortalRadius, PortalRadius) * 32, new Vector2(PortalRadius * 2, PortalRadius * 2) * 32);
    DestRect = new Rect2(portalLocation - new Vector2(PortalRadius, PortalRadius) * 32, new Vector2(PortalRadius * 2, PortalRadius * 2) * 32);

    // draw source rect

    var sr = new Rect2(
      sourceTileMap.MapToLocal(sourceCenter - new Vector2I(PortalRadius, PortalRadius)) - new Vector2(16, 16),
      new Vector2(PortalRadius * 2 * 32, PortalRadius * 2 * 32)
    );

    Nodes.SourceBackground.GlobalPosition = sr.Position;
    Nodes.SourceBackground.Scale = new Vector2 {
      X = sr.Size.X / Nodes.SourceBackground.Texture.GetSize().X,
      Y = sr.Size.Y / Nodes.SourceBackground.Texture.GetSize().Y,
    };

    // draw dest rect

    var dr = new Rect2(
      destTileMap.MapToLocal(destCenter - new Vector2I(PortalRadius, PortalRadius)) - new Vector2(16, 16),
      new Vector2(PortalRadius * 2 * 32, PortalRadius * 2 * 32)
    );

    Nodes.SimpleBackground.GlobalPosition = dr.Position;
    Nodes.SimpleBackground.Scale = new Vector2 {
      X = dr.Size.X / Nodes.SimpleBackground.Texture.GetSize().X,
      Y = dr.Size.Y / Nodes.SimpleBackground.Texture.GetSize().Y,
    };

    // Reset collisions that were cleared last time.
    foreach (var tile in previouslyClearedTiles) {
      sourceTileMap.SetCell(0,
        tile,
        sourceTileMap.GetCellSourceId(0, tile),
        sourceTileMap.GetCellAtlasCoords(0, tile),
        0
      );
    }

    // Clear previous state.
    destTileMap.Clear();
    destRects.Clear();
    sourceRects.Clear();
    previouslyClearedTiles.Clear();

    for (var i = -PortalRadius; i < PortalRadius; i++) {
      for (var j = -PortalRadius; j < PortalRadius; j++) {
        var sourceLocation = sourceCenter + new Vector2I(i, j);
        var destLocation = destCenter + new Vector2I(i, j);
        var sourceTile = sourceTileMap.GetCellTileData(0, sourceLocation);

        var stAtlasCoords = sourceTileMap.GetCellAtlasCoords(0, sourceLocation);

        destTileMap.SetCell(
          0,
          destLocation,
          // sourceTileMap.GetCellSourceId(0, sourceLocation),
          0, // TODO... lol. or maybe not. it works well enough.
          stAtlasCoords
        );

        if (sourceTile != null) {
          var fws = FadingWhiteSquare.New();

          GetParent().AddChild(fws);
          fws.GlobalPosition = destTileMap.ToGlobal(destTileMap.MapToLocal(destLocation)) - new Vector2(16, 16);

          fws.Scale = new Vector2(
            32 / fws.Texture.GetWidth(),
            32 / fws.Texture.GetHeight()
          );
        }

        // Will turn off collision in the original map, temporarily.
        sourceTileMap.SetCell(0,
          destLocation,
          sourceTileMap.GetCellSourceId(0, destLocation),
          sourceTileMap.GetCellAtlasCoords(0, destLocation),
          1
        );
        previouslyClearedTiles.Add(destLocation);

        for (var k = 0; k < 5; k++) {
          await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        }
      }
    }
  }
}
