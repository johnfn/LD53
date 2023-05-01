using Godot;
public partial class LinkRemover : Node2D {
  public static LinkRemover New() {
    return GD.Load<PackedScene>("res://link_remover.tscn").Instantiate<LinkRemover>();
  }
  public LinkRemover() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class LinkRemoverNodes {
    LinkRemover parent;
    public LinkRemoverNodes(LinkRemover parent) {
      this.parent = parent;
    }
    private Sprite2D? _WhiteSquare;
    public Sprite2D WhiteSquare {
      get {
        if (_WhiteSquare == null) {
          _WhiteSquare = parent.GetNode<Sprite2D>("WhiteSquare");
        }
        return _WhiteSquare;
      }
    }

    private Area2D? _Area2D;
    public Area2D Area2D {
      get {
        if (_Area2D == null) {
          _Area2D = parent.GetNode<Area2D>("Area2D");
        }
        return _Area2D;
      }
    }

    private CollisionShape2D? _Area2D_CollisionShape2D;
    public CollisionShape2D Area2D_CollisionShape2D {
      get {
        if (_Area2D_CollisionShape2D == null) {
          _Area2D_CollisionShape2D = parent.GetNode<CollisionShape2D>("Area2D/CollisionShape2D");
        }
        return _Area2D_CollisionShape2D;
      }
    }

    private GpuParticles2D? _XParticles;
    public GpuParticles2D XParticles {
      get {
        if (_XParticles == null) {
          _XParticles = parent.GetNode<GpuParticles2D>("XParticles");
        }
        return _XParticles;
      }
    }

  }

  public LinkRemoverNodes? _Nodes;
  public LinkRemoverNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new LinkRemoverNodes(this);
      }
      return _Nodes;
    }
  }
}
