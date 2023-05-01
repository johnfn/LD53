using Godot;
using System;
using static Utils;

public partial class LinkRemover : Node2D {
  public override void _Ready() {
    Nodes.Area2D.BodyEntered += (body) => {
      if (body is Blub b) {
        if (Mailbox.CurrentlyLinkedMailbox != null) {
          Mailbox.CurrentlyLinkedMailbox.Unlink();
        }
      }
    };
  }
}
