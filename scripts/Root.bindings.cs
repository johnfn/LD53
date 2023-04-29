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

    private TileMap? _DarkWorld;
    public TileMap DarkWorld {
      get {
        if (_DarkWorld == null) {
          _DarkWorld = parent.GetNode<TileMap>("DarkWorld");
        }
        return _DarkWorld;
      }
    }

    private Sprite2D? _FakeBlub;
    public Sprite2D FakeBlub {
      get {
        if (_FakeBlub == null) {
          _FakeBlub = parent.GetNode<Sprite2D>("FakeBlub");
        }
        return _FakeBlub;
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

    private Node2D? _DialogTriggers;
    public Node2D DialogTriggers {
      get {
        if (_DialogTriggers == null) {
          _DialogTriggers = parent.GetNode<Node2D>("DialogTriggers");
        }
        return _DialogTriggers;
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

    private Label? _StaticCanvasLayer_Label;
    public Label StaticCanvasLayer_Label {
      get {
        if (_StaticCanvasLayer_Label == null) {
          _StaticCanvasLayer_Label = parent.GetNode<Label>("StaticCanvasLayer/Label");
        }
        return _StaticCanvasLayer_Label;
      }
    }

    private CanvasLayer? _BackgroundCanvasLayer;
    public CanvasLayer BackgroundCanvasLayer {
      get {
        if (_BackgroundCanvasLayer == null) {
          _BackgroundCanvasLayer = parent.GetNode<CanvasLayer>("BackgroundCanvasLayer");
        }
        return _BackgroundCanvasLayer;
      }
    }

    private Sprite2D? _BackgroundCanvasLayer_Sky;
    public Sprite2D BackgroundCanvasLayer_Sky {
      get {
        if (_BackgroundCanvasLayer_Sky == null) {
          _BackgroundCanvasLayer_Sky = parent.GetNode<Sprite2D>("BackgroundCanvasLayer/Sky");
        }
        return _BackgroundCanvasLayer_Sky;
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

    private DialogTrigger? _DialogTriggers_FirstDialog;
    public DialogTrigger DialogTriggers_FirstDialog {
      get {
        if (_DialogTriggers_FirstDialog == null) {
          _DialogTriggers_FirstDialog = parent.GetNode<DialogTrigger>("DialogTriggers/FirstDialog");
        }
        return _DialogTriggers_FirstDialog;
      }
    }

    private DialogTrigger? _DialogTriggers_FallDialogTrigger;
    public DialogTrigger DialogTriggers_FallDialogTrigger {
      get {
        if (_DialogTriggers_FallDialogTrigger == null) {
          _DialogTriggers_FallDialogTrigger = parent.GetNode<DialogTrigger>("DialogTriggers/FallDialogTrigger");
        }
        return _DialogTriggers_FallDialogTrigger;
      }
    }

    private DialogTrigger? _DialogTriggers_OhShootSpikes;
    public DialogTrigger DialogTriggers_OhShootSpikes {
      get {
        if (_DialogTriggers_OhShootSpikes == null) {
          _DialogTriggers_OhShootSpikes = parent.GetNode<DialogTrigger>("DialogTriggers/OhShootSpikes");
        }
        return _DialogTriggers_OhShootSpikes;
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

    private Mailbox? _Mailbox;
    public Mailbox Mailbox {
      get {
        if (_Mailbox == null) {
          _Mailbox = parent.GetNode<Mailbox>("Mailbox");
        }
        return _Mailbox;
      }
    }

    private Cannon? _Cannon;
    public Cannon Cannon {
      get {
        if (_Cannon == null) {
          _Cannon = parent.GetNode<Cannon>("Cannon");
        }
        return _Cannon;
      }
    }

    private CannonBall? _Cannonball;
    public CannonBall Cannonball {
      get {
        if (_Cannonball == null) {
          _Cannonball = parent.GetNode<CannonBall>("Cannonball");
        }
        return _Cannonball;
      }
    }

    private VortexGun? _VortexGun;
    public VortexGun VortexGun {
      get {
        if (_VortexGun == null) {
          _VortexGun = parent.GetNode<VortexGun>("VortexGun");
        }
        return _VortexGun;
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
