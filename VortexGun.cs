using Godot;
using System;
using static Utils;

public partial class VortexGun : Node2D {
  public override void _Ready() {
  }

  public override void _Process(double delta) {
    Nodes.Aim.GlobalPosition = Root.Instance.Nodes.Blub.GlobalPosition;
  }

  public override void _Input(InputEvent @event) {
    if (@event is InputEventMouseMotion mm) {
      var position = mm.Position;
      var tm = Root.Instance.Nodes.TileMap;
      // round position to nearest tile
      var tilePosition = tm.MapToLocal(tm.LocalToMap(GetGlobalMousePosition()));

      Nodes.Reticle.GlobalPosition = tilePosition;

      Nodes.Aim.End = Nodes.Reticle;
    }
  }
}
