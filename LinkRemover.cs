using Godot;
using System;
using System.Collections.Generic;
using static Utils;

public partial class LinkRemover : Node2D {
  public override void _Ready() {
    Nodes.Area2D.BodyEntered += (body) => {
      if (body is Blub b) {
        if (Mailbox.CurrentlyLinkedMailbox != null) {
          Mailbox.CurrentlyLinkedMailbox.Unlink();

          var randomMessages = new List<string> {
            "Link deactivated.",
            "Link broken.",
            "Rift gun offline."
          };

          b.ShowOverheadText(
            randomMessages[(int)(GD.Randi() % randomMessages.Count)]
          );
        }
      }
    };
  }
}
