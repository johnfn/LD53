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

    private Node2D? _Mailbox;
    public Node2D Mailbox {
      get {
        if (_Mailbox == null) {
          _Mailbox = parent.GetNode<Node2D>("Mailbox");
        }
        return _Mailbox;
      }
    }

    private Sprite2D? _Mailbox_Graphic;
    public Sprite2D Mailbox_Graphic {
      get {
        if (_Mailbox_Graphic == null) {
          _Mailbox_Graphic = parent.GetNode<Sprite2D>("Mailbox/Graphic");
        }
        return _Mailbox_Graphic;
      }
    }

    private Sprite2D? _Mailbox_RippleEffect;
    public Sprite2D Mailbox_RippleEffect {
      get {
        if (_Mailbox_RippleEffect == null) {
          _Mailbox_RippleEffect = parent.GetNode<Sprite2D>("Mailbox/RippleEffect");
        }
        return _Mailbox_RippleEffect;
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
