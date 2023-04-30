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

    // First, let's just see if we can even make it to the end w/o hitting a wall

    var spaceState = GetWorld2D().DirectSpaceState;
    var query = PhysicsRayQueryParameters2D.Create(GlobalPosition, GetGlobalMousePosition());
    var result = spaceState.IntersectRay(query);

    if (result != null && result.Keys.Contains("position")) {
      var collision = (Godot.Collections.Dictionary)result;
      var position = (Vector2)collision["position"];

      end = ToLocal(position);
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

    // Finally, draw reticule.

    var tm = Root.Instance.Nodes.TileMap;
    // round position to nearest tile
    var tilePosition = tm.MapToLocal(tm.LocalToMap(ToGlobal(end)));

    Nodes.Reticle.GlobalPosition = tilePosition;

    // TODO: If the reticle is on a wall, we should push it closer to the source.
  }
}