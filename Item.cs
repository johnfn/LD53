using Godot;
using System;
using static Utils;

public enum ItemType {
  VortexGun
}

public partial class Item : Node2D {
  public override void _Ready() {
    Nodes.AnimationPlayer_PlayBobble();

    Nodes.Area2D.BodyEntered += (body) => {
      if (body is Blub p) {
        p.PickupItem(ItemType.VortexGun);

        QueueFree();
      }
    };
  }

  public override void _Process(double delta) {
  }
}
