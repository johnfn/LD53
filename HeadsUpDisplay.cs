using Godot;
using System;
using static Utils;

public partial class HeadsUpDisplay : CanvasLayer {
  public static bool IsInsidePortal = false;

  public override void _Ready() {
  }

  public override void _Process(double delta) {
    var player = Root.Instance.Nodes.Blub;
    var allPortals = GetTree().GetNodesInGroup("Portal");
    var allMailboxAreas = GetTree().GetNodesInGroup("MailboxArea");
    var isTouchingPortal = false;

    foreach (var portal in allPortals) {
      if (portal is Area2D area) {
        if (area.GetOverlappingBodies().Contains(player)) {
          var mailboxParent = area.GetParent().GetParent();

          if (mailboxParent is Mailbox mb && mb.IsLinked) {
            isTouchingPortal = true;

            break;
          }
        }
      }
    }

    IsInsidePortal = isTouchingPortal;

    foreach (var mailboxArea in allMailboxAreas) {
      if (mailboxArea is Area2D area) {
        if (area.GetOverlappingBodies().Contains(player)) {
          var mailbox = (Mailbox)area.GetParent();

          if (!mailbox.IsLinked && player.HasVortexGun) {
            if (Nodes.EActionLabel.Text == "") {
              Nodes.AnimationPlayer.Play("ShowLabel");
            }

            Nodes.EActionLabel.Text = "E: Link";
            Nodes.EActionLabel.Modulate = new Color(1, 1, 1, 1);

            if (Input.IsActionJustPressed("swap")) {
              mailbox.Link();

            }

            return;
          }

          break;
        }
      }
    }

    if (isTouchingPortal) {
      if (Nodes.EActionLabel.Text == "") {
        Nodes.AnimationPlayer.Play("ShowLabel");
      }

      Nodes.EActionLabel.Text = "E: Warp";
      Nodes.EActionLabel.Modulate = new Color(1, 1, 1, 1);
    } else {
      Nodes.EActionLabel.Text = "";
      Nodes.EActionLabel.Modulate = new Color(1, 1, 1, 0);
    }
  }
}
