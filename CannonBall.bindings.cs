using Godot;
public partial class CannonBall : RigidBody2D {
  public static CannonBall New() {
    return GD.Load<PackedScene>("res://cannonball.tscn").Instantiate<CannonBall>();
  }
  public CannonBall() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CannonBallNodes {
    CannonBall parent;
    public CannonBallNodes(CannonBall parent) {
      this.parent = parent;
    }
    private Sprite2D? _Graphic;
    public Sprite2D Graphic {
      get {
        if (_Graphic == null) {
          _Graphic = parent.GetNode<Sprite2D>("Graphic");
        }
        return _Graphic;
      }
    }

    private CollisionShape2D? _CollisionShape2D;
    public CollisionShape2D CollisionShape2D {
      get {
        if (_CollisionShape2D == null) {
          _CollisionShape2D = parent.GetNode<CollisionShape2D>("CollisionShape2D");
        }
        return _CollisionShape2D;
      }
    }

  }

  public CannonBallNodes? _Nodes;
  public CannonBallNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new CannonBallNodes(this);
      }
      return _Nodes;
    }
  }
}
