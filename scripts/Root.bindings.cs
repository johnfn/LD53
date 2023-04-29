using Godot;
public partial class Root : Node2D {
  public static Root New() {
    return GD.Load<PackedScene>("res://Root.tscn").Instantiate<Root>();
  }
  public Root() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class RootNodes {
    Root parent;
    public RootNodes(Root parent) {
      this.parent = parent;
    }
    private TileMap? _TileMap;
    public TileMap TileMap {
      get {
        if (_TileMap == null) {
          _TileMap = parent.GetNode<TileMap>("TileMap");
        }
        return _TileMap;
      }
    }

    private CharacterBody2D? _Blub;
    public CharacterBody2D Blub {
      get {
        if (_Blub == null) {
          _Blub = parent.GetNode<CharacterBody2D>("Blub");
        }
        return _Blub;
      }
    }

    private Sprite2D? _Blub_Graphic;
    public Sprite2D Blub_Graphic {
      get {
        if (_Blub_Graphic == null) {
          _Blub_Graphic = parent.GetNode<Sprite2D>("Blub/Graphic");
        }
        return _Blub_Graphic;
      }
    }

    private CollisionShape2D? _Blub_CollisionShape2D;
    public CollisionShape2D Blub_CollisionShape2D {
      get {
        if (_Blub_CollisionShape2D == null) {
          _Blub_CollisionShape2D = parent.GetNode<CollisionShape2D>("Blub/CollisionShape2D");
        }
        return _Blub_CollisionShape2D;
      }
    }

    private Camera2D? _Camera2D;
    public Camera2D Camera2D {
      get {
        if (_Camera2D == null) {
          _Camera2D = parent.GetNode<Camera2D>("Camera2D");
        }
        return _Camera2D;
      }
    }

  }

  public RootNodes? _Nodes;
  public RootNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new RootNodes(this);
      }
      return _Nodes;
    }
  }
}
