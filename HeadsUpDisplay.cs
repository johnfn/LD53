using Godot;
using System;

public partial class HeadsUpDisplay : CanvasLayer {
  public override void _Ready() {
  }

  public override void _Process(double delta) {
    var player = Root.Instance.Nodes.Blub;
    var allPortals = GetTree().GetNodesInGroup("Portal");
    var isTouchingPortal = false;

    foreach (var portal in allPortals) {
      if (portal is Area2D area) {
        if (area.GetOverlappingBodies().Contains(player)) {
          isTouchingPortal = true;

          break;
        }
      }
    }

    if (isTouchingPortal) {
      player.Modulate = new Color(1, 1, 1, 0.3f);

      if (Nodes.EActionLabel.Text == "") {
        Nodes.AnimationPlayer.Play("ShowLabel");
      }

      Nodes.EActionLabel.Text = "E: Warp";
      Nodes.EActionLabel.Modulate = new Color(1, 1, 1, 1);
    } else {
      player.Modulate = new Color(1, 1, 1, 1f);

      Nodes.EActionLabel.Text = "";
      Nodes.EActionLabel.Modulate = new Color(1, 1, 1, 0);
    }
  }
}
