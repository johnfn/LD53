using Godot;
using System;
using System.Collections.Generic;
using static Utils;

public partial class SaveStation : Node2D {
  public static SaveStation? ActiveSaveStation = null;
  public static bool HasExplained = false;

  public override void _Ready() {
    Modulate = new Color(1, 1, 1, 0.3f);
    Nodes.FakeGlow3.Visible = false;
    Nodes.SaveStationParticles.Visible = false;
  }

  public override void _Process(double delta) {
    if (ActiveSaveStation != this) {
      foreach (var body in Nodes.Area2D.GetOverlappingBodies()) {
        if (body is Blub player && player.IsOnFloor()) {
          SetActive();
        }
      }
    }
  }

  private void SetActive() {
    if (ActiveSaveStation != null) {
      ActiveSaveStation.Nodes.FakeGlow3.Visible = false;
      ActiveSaveStation.Modulate = new Color(1, 1, 1, 0.3f);
      ActiveSaveStation.Nodes.SaveStationParticles.Visible = false;
    }

    ActiveSaveStation = this;
    ActiveSaveStation.Nodes.SaveStationParticles.Visible = true;
    ActiveSaveStation.Nodes.FakeGlow3.Visible = true;
    ActiveSaveStation.Nodes.AnimationPlayer_PlayPulse();
    Modulate = new Color(1, 1, 1, 1);

    if (!SaveStation.HasExplained) {
      SaveStation.HasExplained = true;

      var _ = Root.Instance.Nodes.Blub.TriggerDialog(
        DialogTriggerName.SaveStation
      );
    } else {
      var randomMessages = new List<string> {
        "Save station activated!",
        "Save station ready to go.",
        "Save station online.",
        "Save station ready.",
      };

      Root.Instance.Nodes.Blub.ShowOverheadText(
        randomMessages[(int)(GD.Randi() % randomMessages.Count)]
      );
    }
  }
}
