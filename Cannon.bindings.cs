using Godot;
public partial class Cannon : Node2D {
  public static Cannon New() {
    return GD.Load<PackedScene>("res://cannon.tscn").Instantiate<Cannon>();
  }
  public Cannon() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class CannonNodes {
    Cannon parent;
    public CannonNodes(Cannon parent) {
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

    private StaticBody2D? _StaticBody2D;
    public StaticBody2D StaticBody2D {
      get {
        if (_StaticBody2D == null) {
          _StaticBody2D = parent.GetNode<StaticBody2D>("StaticBody2D");
        }
        return _StaticBody2D;
      }
    }

    private CollisionShape2D? _StaticBody2D_CollisionShape2D;
    public CollisionShape2D StaticBody2D_CollisionShape2D {
      get {
        if (_StaticBody2D_CollisionShape2D == null) {
          _StaticBody2D_CollisionShape2D = parent.GetNode<CollisionShape2D>("StaticBody2D/CollisionShape2D");
        }
        return _StaticBody2D_CollisionShape2D;
      }
    }

  }

  public CannonNodes? _Nodes;
  public CannonNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new CannonNodes(this);
      }
      return _Nodes;
    }
  }
}
