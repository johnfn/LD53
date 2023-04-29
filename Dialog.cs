using Godot;
using System;

public partial class Dialog : PanelContainer {
  public override void _Ready() {
    Hide();
  }

  public void StartDialog(DialogTriggerName name) {
    Show();

    Nodes.MarginContainer_Label.Text = name.ToString();
  }
}
