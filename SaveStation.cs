using Godot;
using System;
using static Utils;

public partial class SaveStation : Node2D {
  public static SaveStation? ActiveSaveStation = null;

  public override void _Ready() {
    Modulate = new Color(1, 1, 1, 0.3f);
    Nodes.FakeGlow3.Visible = false;
  }

  public override void _Process(double delta) {
    foreach (var body in Nodes.Area2D.GetOverlappingBodies()) {
      if (body is Blub player && player.IsOnFloor()) {
        SetActive();
      }
    }
  }

  private void SetActive() {
    if (ActiveSaveStation != null) {
      ActiveSaveStation.Nodes.FakeGlow3.Visible = false;
      ActiveSaveStation.Modulate = new Color(1, 1, 1, 0.3f);
    }

    ActiveSaveStation = this;
    ActiveSaveStation.Nodes.FakeGlow3.Visible = true;
    ActiveSaveStation.Nodes.AnimationPlayer_PlayPulse();
    Modulate = new Color(1, 1, 1, 1);
  }
}
