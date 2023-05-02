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

  public override void _Ready() {
    Nodes.AnimationPlayer.Play("Reticle");
    Nodes.TooClose.Visible = false;
  }

  public override void _Process(double delta) {
    _offset += AnimationSpeed * delta;

    if (_offset > DashLength + GapLength) {
      _offset = 0.0f;
    }

    QueueRedraw();
  }

  // detect a click
  public override void _Input(InputEvent @event) {
    if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed) {
      var portalSource = Mailbox.CurrentlyLinkedMailbox;

      if (Nodes.Reticle.Visible) {
        if (portalSource != null) {
          portalSource.CreatePortalAt(
            Nodes.Reticle.GlobalPosition
          );
        }
      } else {
        // dont disable initial portals b4 we even used them.
        if (Root.Instance.Nodes.Blub.HasVortexGun) {
          var allMailboxes = GetTree().GetNodesInGroup("Mailbox");

          foreach (var mailbox in allMailboxes) {
            if (mailbox is Mailbox mailboxNode) {
              mailboxNode.ClearPortal();
            }
          }
        }
      }
    }
  }

  public override void _Draw() {
    var player = Root.Instance.Nodes.Blub;
    var mailbox = Mailbox.CurrentlyLinkedMailbox;

    if (mailbox == null || !player.LastActionWasMouse) {
      Nodes.SourceBackground.Visible = false;
      Nodes.Reticle.Visible = false;

      // Also done in Aim.cs for reasons.
      Root.Instance.Nodes.DarkWorldPreview.Clear();

      return;
    }

    Nodes.Reticle.Visible = true;

    var start = Vector2.Zero;
    var end = ToLocal(GetGlobalMousePosition());
    var endReasonablyCloseToMouse = true;

    // First, let's just see if we can even make it to the end w/o hitting a wall

    var spaceState = GetWorld2D().DirectSpaceState;
    var query = PhysicsRayQueryParameters2D.Create(
      GlobalPosition,
      GetGlobalMousePosition(),
      uint.MaxValue
      & ~(uint)(Globals.LayerNumbers[LayerMask.Cannonball])
      & ~(uint)(Globals.LayerNumbers[LayerMask.Ladder])
    );
    var result = spaceState.IntersectRay(query);

    if (result != null && result.Keys.Contains("position")) {
      endReasonablyCloseToMouse = false;

      var collision = (Godot.Collections.Dictionary)result;
      var globalPosition = (Vector2)collision["position"];

      // walk position backwards, until we no longer collide w anything. Or just give up. Who knows!

      var dir = (globalPosition - GlobalPosition).Normalized();

      for (int i = 0; i < 10; i++) {
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

    // Draw dashed line.

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

    var previewRect = new Rect2(
      GetGlobalMousePosition() - new Vector2(Mailbox.PortalRadius * 32, Mailbox.PortalRadius * 32),
      new Vector2(Mailbox.PortalRadius * 2 * 32, Mailbox.PortalRadius * 2 * 32)
    );

    var playerRect = Root.Instance.Nodes.Blub.Nodes.Graphic.GetRect();
    var playerGlobalRect = new Rect2(
      Root.Instance.Nodes.Blub.GlobalPosition + playerRect.Position,
      playerRect.Size
    );

    if (!endReasonablyCloseToMouse) {
      if (player.LastActionWasMouse) {
        Nodes.TooClose.Visible = true;
        Nodes.TooClose.Text = "No clear shot!";
        Nodes.TooClose.GlobalPosition = GetGlobalMousePosition();
      }
    }

    if (previewRect.Intersects(playerGlobalRect)) {
      endReasonablyCloseToMouse = false;

      if (player.LastActionWasMouse) {
        Nodes.TooClose.Visible = true;
        Nodes.TooClose.Text = "Too close!";
        Nodes.TooClose.GlobalPosition = GetGlobalMousePosition();
      }
    }

    if (!endReasonablyCloseToMouse) {
      Nodes.SourceBackground.Visible = false;
      Nodes.Reticle.Visible = false;
      Root.Instance.Nodes.DarkWorldPreview.Visible = false;

      return;
    }

    Nodes.TooClose.Visible = false;

    // Draw rest of preview.

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

    if (Mailbox.CurrentlyLinkedMailbox != null) {
      Mailbox.CurrentlyLinkedMailbox.ShowPortalPreviewAt(
        Nodes.Reticle.GlobalPosition
      );
    }
  }
}
