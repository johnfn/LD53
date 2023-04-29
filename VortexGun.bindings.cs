using Godot;
public partial class VortexGun : Node2D {
  public static VortexGun New() {
    return GD.Load<PackedScene>("res://vortex_gun.tscn").Instantiate<VortexGun>();
  }
  public VortexGun() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class VortexGunNodes {
    VortexGun parent;
    public VortexGunNodes(VortexGun parent) {
      this.parent = parent;
    }
    private Sprite2D? _Reticle;
    public Sprite2D Reticle {
      get {
        if (_Reticle == null) {
          _Reticle = parent.GetNode<Sprite2D>("Reticle");
        }
        return _Reticle;
      }
    }

    private Aim? _Aim;
    public Aim Aim {
      get {
        if (_Aim == null) {
          _Aim = parent.GetNode<Aim>("Aim");
        }
        return _Aim;
      }
    }

  }

  public VortexGunNodes? _Nodes;
  public VortexGunNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new VortexGunNodes(this);
      }
      return _Nodes;
    }
  }
}
