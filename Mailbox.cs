using Godot;
using System;
using System.Collections.Generic;
using static Utils;

public partial class Mailbox : Node2D {
  public bool PortalExists = false;
  public static Mailbox? CurrentlyLinkedMailbox = null;
  public bool IsLinked = false;
  public Vector2 PortalTopLeft;
  public Rect2 SourceRect;
  public Rect2 DestRect;
  public static int PortalRadius = 3;
  public static bool HasExplainedLinking = false;

  [Export]
  public bool AutoCreate = false;
  private bool _hasAutoCreated = false;

  public override void _Ready() {
    Nodes.SimpleBackground.Hide();
    Nodes.SourceBackground.Hide();
    Nodes.MailboxActive_LinearGradient.Hide();
    Nodes.MailboxActive_MailboxParticles.Visible = false;
  }

  public void Unlink() {
    if (CurrentlyLinkedMailbox != null) {
      CurrentlyLinkedMailbox.Nodes.MailboxActive_LinearGradient.Hide();
      CurrentlyLinkedMailbox.IsLinked = false;
      CurrentlyLinkedMailbox.Nodes.MailboxActive_MailboxParticles.Visible = false;
      CurrentlyLinkedMailbox.Nodes.SourceBackground.Hide();

      CurrentlyLinkedMailbox = null;
    }
  }

  public void Link() {
    Unlink();

    IsLinked = true;
    CurrentlyLinkedMailbox = this;
    Nodes.MailboxActive_LinearGradient.Show();
    Nodes.MailboxActive_AnimationPlayer.Play("Active");
    CurrentlyLinkedMailbox.Nodes.MailboxActive_MailboxParticles.Visible = true;
    Nodes.SourceBackground.Show();

    SourceRect = new Rect2(
      getSourceTopLeft(),
      new Vector2(PortalRadius * 2 * 32, PortalRadius * 2 * 32)
    );

    Nodes.SourceBackground.GlobalPosition = SourceRect.Position;
    Nodes.SourceBackground.Scale = new Vector2 {
      X = SourceRect.Size.X / Nodes.SourceBackground.Texture.GetSize().X,
      Y = SourceRect.Size.Y / Nodes.SourceBackground.Texture.GetSize().Y,
    };

    if (!Mailbox.HasExplainedLinking) {
      Mailbox.HasExplainedLinking = true;

      var _ = Root.Instance.Nodes.Blub.TriggerDialog(
        DialogTriggerName.LinkMailbox
      );
    }
  }

  public override void _Process(double delta) {
    var fakeBlub = Root.Instance.Nodes.FakeBlub;
    fakeBlub.Visible = true;

    if (AutoCreate && !_hasAutoCreated) {
      _hasAutoCreated = true;

      Node2D target = (Node2D)GetNode("Target")!;
      CreatePortalAt(target.GlobalPosition + new Vector2(32, 32) * PortalRadius);
    }

    if (PortalExists) {
      var sourceTopLeft = getSourceTopLeft();
      var portalDelta = sourceTopLeft - PortalTopLeft;
      var player = Root.Instance.Nodes.Blub;
      var playerRect = new Rect2(player.GlobalPosition, new Vector2(16, 16));

      if (playerRect.Intersects(SourceRect)) {
        fakeBlub.GlobalPosition = Root.Instance.Nodes.Blub.GlobalPosition - portalDelta;

        fakeBlub.Nodes.Graphic.Visible = false;
        fakeBlub.Nodes.GraphicAlt.Visible = true;

        player.Nodes.GraphicAlt.Visible = false;
        player.Nodes.Graphic.Visible = true;

        if (Input.IsActionJustPressed("swap")) {
          Audio.Instance.Nodes.Warp.Play();
          Root.Instance.Nodes.Blub.GlobalPosition = Root.Instance.Nodes.Blub.GlobalPosition - portalDelta;
        }
      } else if (playerRect.Intersects(DestRect)) {
        fakeBlub.GlobalPosition = Root.Instance.Nodes.Blub.GlobalPosition + portalDelta;

        fakeBlub.Nodes.Graphic.Visible = true;
        fakeBlub.Nodes.GraphicAlt.Visible = false;

        player.Nodes.GraphicAlt.Visible = false;
        player.Nodes.Graphic.Visible = true;

        if (Input.IsActionJustPressed("swap")) {
          Audio.Instance.Nodes.Warp.Play();
          Root.Instance.Nodes.Blub.GlobalPosition = Root.Instance.Nodes.Blub.GlobalPosition + portalDelta;
        }
      } else {
        player.Nodes.Graphic.Visible = true;
        player.Nodes.GraphicAlt.Visible = false;

        fakeBlub.Nodes.Graphic.Visible = false;
        fakeBlub.Nodes.GraphicAlt.Visible = false;
      }
    }
  }

  public void ShowPortalPreviewAt(Vector2 globalPosition) {
    // Draw preview rectangle to preview tilemap.

    var sourceTileMap = Root.Instance.Nodes.TileMap;
    var previewTileMap = Root.Instance.Nodes.DarkWorldPreview;
    var portalRadius = Mailbox.PortalRadius;
    var sourceTopLeft = getSourceTopLeft();

    // Also done in Aim.cs for reasons.
    previewTileMap.Clear();

    for (var i = 0; i < portalRadius * 2; i++) {
      for (var j = 0; j < portalRadius * 2; j++) {
        var sourceLocation = previewTileMap.LocalToMap(sourceTopLeft) + new Vector2I(i, j);
        var destLocation = previewTileMap.LocalToMap(
          previewTileMap.ToLocal(globalPosition)
        ) + new Vector2I(i, j) - new Vector2I(PortalRadius, PortalRadius);
        var sourceTile = sourceTileMap.GetCellTileData(0, sourceLocation);

        previewTileMap.SetCell(
          0,
          destLocation,
          2,
          sourceTileMap.GetCellAtlasCoords(0, sourceLocation),
          1 // no collision on these guys, theyre just previews
        );
      }
    }
  }

  private Vector2 getSourceTopLeft() {
    var sourceTileMap = Root.Instance.Nodes.TileMap;
    var sourceCenter = sourceTileMap.LocalToMap(GlobalPosition);

    return sourceTileMap.MapToLocal(sourceCenter - new Vector2I(PortalRadius, PortalRadius)) - new Vector2(16, 16);
  }

  public void ClearPortal(bool del = false) {
    var sourceTileMap = Root.Instance.Nodes.TileMap;
    var destTileMap = Root.Instance.Nodes.DarkWorld;

    Nodes.SimpleBackground.Hide();
    Nodes.SourceBackground.Hide();

    // Reset collisions that were cleared last time.
    foreach (var tile in prevPortalTiles) {
      sourceTileMap.SetCell(0,
        tile,
        sourceTileMap.GetCellSourceId(0, tile),
        sourceTileMap.GetCellAtlasCoords(0, tile),
        0
      );

      destTileMap.SetCell(
        0,
        tile,
        -1,
        destTileMap.GetCellAtlasCoords(0, tile),
        0
      );
    }

    if (prevPortalTiles.Count > 0) {
      Audio.Instance.Nodes.ClosePortal.Play();
    }

    // Clear previous state.
    prevPortalTiles.Clear();
  }

  List<Vector2I> prevPortalTiles = new();

  public async void CreatePortalAt(Vector2 globalPosition) {
    ClearPortal();

    Nodes.SimpleBackground.Show();
    Nodes.SourceBackground.Show();

    Nodes.AnimationPlayer.Play("PulseBorder");

    Nodes.SimpleBackground_PortalParticles.Restart();
    Nodes.SourceBackground_PortalParticles.Restart();

    PortalExists = true;

    var portalLocation = globalPosition;
    var sourceTileMap = Root.Instance.Nodes.TileMap;
    var sourceCenter = sourceTileMap.LocalToMap(GlobalPosition);

    var destTileMap = Root.Instance.Nodes.DarkWorld;
    var destCenter = destTileMap.LocalToMap(portalLocation);

    // draw source rect

    SourceRect = new Rect2(
      getSourceTopLeft(),
      new Vector2(PortalRadius * 2 * 32, PortalRadius * 2 * 32)
    );

    Nodes.SourceBackground.GlobalPosition = SourceRect.Position;
    Nodes.SourceBackground.Scale = new Vector2 {
      X = SourceRect.Size.X / Nodes.SourceBackground.Texture.GetSize().X,
      Y = SourceRect.Size.Y / Nodes.SourceBackground.Texture.GetSize().Y,
    };

    // draw dest rect

    DestRect = new Rect2(
      destTileMap.MapToLocal(destCenter - new Vector2I(PortalRadius, PortalRadius)) - new Vector2(16, 16),
      new Vector2(PortalRadius * 2 * 32, PortalRadius * 2 * 32)
    );

    PortalTopLeft = DestRect.Position;

    Nodes.SimpleBackground.GlobalPosition = DestRect.Position;
    Nodes.SimpleBackground.Scale = new Vector2 {
      X = DestRect.Size.X / Nodes.SimpleBackground.Texture.GetSize().X,
      Y = DestRect.Size.Y / Nodes.SimpleBackground.Texture.GetSize().Y,
    };

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
          0, // outlines.
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
        prevPortalTiles.Add(destLocation);

        for (var k = 0; k < 2; k++) {
          await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        }
      }
    }
  }
}
