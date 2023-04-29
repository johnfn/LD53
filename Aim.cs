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
  }

  public override void _Draw() {
    if (End == null) {
      return;
    }

    var start = Vector2.Zero;
    var end = ToLocal(End.GlobalPosition);
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
  }

}
