using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class Dialog : PanelContainer {
  public override void _Ready() {
    Hide();
  }

  public async Task RunDialog(DialogTriggerName name) {
    Show();

    var dialog = DialogText.Dialogs[name];

    await _ShowDialog(dialog);

    Hide();
  }

  private async Task _ShowDialog(List<string> dialog) {
    foreach (var str in dialog) {
      Nodes.VBoxContainer_Button.Text = "";
      Nodes.VBoxContainer_MarginContainer_Label.Text = str;

      Nodes.VBoxContainer_MarginContainer_Label.VisibleCharacters = 0;

      foreach (var c in str) {
        await ToSignal(GetTree().CreateTimer(0.02), SceneTreeTimer.SignalName.Timeout);

        Nodes.VBoxContainer_MarginContainer_Label.VisibleCharacters += 1;
      }

      Nodes.VBoxContainer_Button.Text = "Next (Space)";

      while (true) {
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

        if (Input.IsActionJustPressed("jump")) {
          break;
        }
      }
    }

    // wait a sec so that the player doesn't jump.
    await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
  }
}
