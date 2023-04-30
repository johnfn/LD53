using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Utils;

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
        for (var i = 0; i < 4; i++) {
          await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

          if (Input.IsActionJustPressed("swap")) {
            goto outer;
          }
        }

        Nodes.VBoxContainer_MarginContainer_Label.VisibleCharacters += 1;
      }

    outer:
      await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
      await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

      Nodes.VBoxContainer_MarginContainer_Label.VisibleCharacters = str.Length;

      Nodes.VBoxContainer_Button.Text = "Next (E)";

      while (true) {
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

        if (Input.IsActionJustPressed("swap")) {
          break;
        }
      }
    }

    // wait a sec so that the player doesn't jump.
    await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
  }
}
