using Godot;
public partial class Aim : Node2D {
  public static Aim New() {
    return GD.Load<PackedScene>("res://aim.tscn").Instantiate<Aim>();
  }
  public Aim() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class AimNodes {
    Aim parent;
    public AimNodes(Aim parent) {
      this.parent = parent;
    }
  }

  public AimNodes? _Nodes;
  public AimNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new AimNodes(this);
      }
      return _Nodes;
    }
  }
}
