using Godot;
using System;
using static Utils;

public partial class Aim : Node2D {
  public double DashLength = 10;
  public double GapLength = 10;
  public double Thickness = 5;
  public Color Color = Colors.White;
  public double AnimationSpeed = 50.0f;

  public Node2D? End = null;

  private double _offset = 0.0f;

  public override void _Process(double delta) {
    _offset += AnimationSpeed * delta;

    if (_offset > DashLength + GapLength) {
      _offset = 0.0f;
    }

    QueueRedraw();

    Nodes.AnimationPlayer.Play("Reticle");
  }

  // detect a click
  public override void _Input(InputEvent @event) {
    if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed) {
      var portalSource = Root.Instance.Nodes.Mailbox;

      portalSource.CreatePortalAt(
        Nodes.Reticle.GlobalPosition
      );
    }
  }

  public override void _Draw() {
    var start = Vector2.Zero;
    var end = ToLocal(GetGlobalMousePosition());
    var endReasonablyCloseToMouse = true;

    // First, let's just see if we can even make it to the end w/o hitting a wall

    var spaceState = GetWorld2D().DirectSpaceState;
    var query = PhysicsRayQueryParameters2D.Create(
      GlobalPosition,
      GetGlobalMousePosition(),
      uint.MaxValue // but not Cannonball
      & ~(uint)(Globals.LayerNumbers[LayerMask.Cannonball])
    );
    var result = spaceState.IntersectRay(query);

    if (result != null && result.Keys.Contains("position")) {
      endReasonablyCloseToMouse = false;

      var collision = (Godot.Collections.Dictionary)result;
      var globalPosition = (Vector2)collision["position"];

      // walk position backwards, until we no longer collide w anything. Or just give up. Who knows!

      var dir = (globalPosition - GlobalPosition).Normalized();

      for (int i = 0; i < 100; i++) {
        var candidatePosition = GetGlobalMousePosition() - dir * (float)i;
        query.From = GlobalPosition;
        query.To = candidatePosition;
        var result2 = spaceState.IntersectRay(query);

        if (result2 == null || !result2.Keys.Contains("position")) {
          end = ToLocal(candidatePosition);
          endReasonablyCloseToMouse = true;

          break;
        }
      }

      if (!endReasonablyCloseToMouse) {
        end = ToLocal(globalPosition);
      }
    }

    double lineLength = start.DistanceTo(end);
    var firstOffset = -_offset;

    var direction = (end - start).Normalized();
    var normal = new Vector2(direction.Y, -direction.X) * (float)Thickness * 0.5f;

    var currentPosition = start;
    double currentLength = 0.0f;

    while (currentLength < lineLength) {
      var nextDashEnd = currentPosition + direction * (float)(DashLength - firstOffset);
      firstOffset = 0;
      var nextGapStart = nextDashEnd + direction * (float)GapLength;

      if (currentLength + DashLength > lineLength) {
        nextDashEnd = end;
      }

      DrawColoredPolygon(new Vector2[] { currentPosition - normal, currentPosition + normal, nextDashEnd + normal, nextDashEnd - normal }, Color);

      currentPosition = nextGapStart;
      currentLength += DashLength + GapLength;
    }

    if (!endReasonablyCloseToMouse) {
      Nodes.SourceBackground.Visible = false;
      Nodes.Reticle.Visible = false;
      Root.Instance.Nodes.DarkWorldPreview.Visible = false;

      return;
    }

    // Draw stuff.

    Nodes.SourceBackground.Visible = true;
    Nodes.Reticle.Visible = true;
    Root.Instance.Nodes.DarkWorldPreview.Visible = true;

    // Draw reticule.

    var tm = Root.Instance.Nodes.TileMap;
    var localTilePosition = tm.LocalToMap(ToGlobal(end));
    // round position to nearest tile
    var tilePosition = tm.MapToLocal(localTilePosition) - new Vector2(16, 16);

    Nodes.Reticle.GlobalPosition = tilePosition;

    // Draw source rectangle.

    Nodes.SourceBackground.GlobalPosition = Nodes.Reticle.GlobalPosition - new Vector2(
      Mailbox.PortalRadius * 32,
      Mailbox.PortalRadius * 32
    );
    Nodes.SourceBackground.Scale = new Vector2 {
      X = (Mailbox.PortalRadius * 2 * 32) / Nodes.SourceBackground.Texture.GetSize().X,
      Y = (Mailbox.PortalRadius * 2 * 32) / Nodes.SourceBackground.Texture.GetSize().Y,
    };

    // Draw portal preview.

    Root.Instance.Nodes.Mailbox.ShowPortalPreviewAt(
      Nodes.Reticle.GlobalPosition
    );
  }
}
