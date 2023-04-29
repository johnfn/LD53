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

    private Camera2D? _Camera2D;
    public Camera2D Camera2D {
      get {
        if (_Camera2D == null) {
          _Camera2D = parent.GetNode<Camera2D>("Camera2D");
        }
        return _Camera2D;
      }
    }

    private CanvasLayer? _StaticCanvasLayer;
    public CanvasLayer StaticCanvasLayer {
      get {
        if (_StaticCanvasLayer == null) {
          _StaticCanvasLayer = parent.GetNode<CanvasLayer>("StaticCanvasLayer");
        }
        return _StaticCanvasLayer;
      }
    }

    private Blub? _Blub;
    public Blub Blub {
      get {
        if (_Blub == null) {
          _Blub = parent.GetNode<Blub>("Blub");
        }
        return _Blub;
      }
    }

    private DialogTrigger? _DialogTrigger;
    public DialogTrigger DialogTrigger {
      get {
        if (_DialogTrigger == null) {
          _DialogTrigger = parent.GetNode<DialogTrigger>("DialogTrigger");
        }
        return _DialogTrigger;
      }
    }

    private Dialog? _StaticCanvasLayer_Dialog;
    public Dialog StaticCanvasLayer_Dialog {
      get {
        if (_StaticCanvasLayer_Dialog == null) {
          _StaticCanvasLayer_Dialog = parent.GetNode<Dialog>("StaticCanvasLayer/Dialog");
        }
        return _StaticCanvasLayer_Dialog;
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
