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
    private Node2D? _GlowHacks;
    public Node2D GlowHacks {
      get {
        if (_GlowHacks == null) {
          _GlowHacks = parent.GetNode<Node2D>("GlowHacks");
        }
        return _GlowHacks;
      }
    }

    private Sprite2D? _GlowHacks_FakeGlow3;
    public Sprite2D GlowHacks_FakeGlow3 {
      get {
        if (_GlowHacks_FakeGlow3 == null) {
          _GlowHacks_FakeGlow3 = parent.GetNode<Sprite2D>("GlowHacks/FakeGlow3");
        }
        return _GlowHacks_FakeGlow3;
      }
    }

    private Sprite2D? _GlowHacks_FakeGlow4;
    public Sprite2D GlowHacks_FakeGlow4 {
      get {
        if (_GlowHacks_FakeGlow4 == null) {
          _GlowHacks_FakeGlow4 = parent.GetNode<Sprite2D>("GlowHacks/FakeGlow4");
        }
        return _GlowHacks_FakeGlow4;
      }
    }

    private Sprite2D? _GlowHacks_LinearGradient;
    public Sprite2D GlowHacks_LinearGradient {
      get {
        if (_GlowHacks_LinearGradient == null) {
          _GlowHacks_LinearGradient = parent.GetNode<Sprite2D>("GlowHacks/LinearGradient");
        }
        return _GlowHacks_LinearGradient;
      }
    }

    private Sprite2D? _GlowHacks_CrystalGlow;
    public Sprite2D GlowHacks_CrystalGlow {
      get {
        if (_GlowHacks_CrystalGlow == null) {
          _GlowHacks_CrystalGlow = parent.GetNode<Sprite2D>("GlowHacks/CrystalGlow");
        }
        return _GlowHacks_CrystalGlow;
      }
    }

    private GpuParticles2D? _GlowHacks_LavaParticles1;
    public GpuParticles2D GlowHacks_LavaParticles1 {
      get {
        if (_GlowHacks_LavaParticles1 == null) {
          _GlowHacks_LavaParticles1 = parent.GetNode<GpuParticles2D>("GlowHacks/LavaParticles1");
        }
        return _GlowHacks_LavaParticles1;
      }
    }

    private GpuParticles2D? _GlowHacks_LavaParticles2;
    public GpuParticles2D GlowHacks_LavaParticles2 {
      get {
        if (_GlowHacks_LavaParticles2 == null) {
          _GlowHacks_LavaParticles2 = parent.GetNode<GpuParticles2D>("GlowHacks/LavaParticles2");
        }
        return _GlowHacks_LavaParticles2;
      }
    }

    private GpuParticles2D? _GlowHacks_LavaParticles3;
    public GpuParticles2D GlowHacks_LavaParticles3 {
      get {
        if (_GlowHacks_LavaParticles3 == null) {
          _GlowHacks_LavaParticles3 = parent.GetNode<GpuParticles2D>("GlowHacks/LavaParticles3");
        }
        return _GlowHacks_LavaParticles3;
      }
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

    private TileMap? _DarkWorldPreview;
    public TileMap DarkWorldPreview {
      get {
        if (_DarkWorldPreview == null) {
          _DarkWorldPreview = parent.GetNode<TileMap>("DarkWorldPreview");
        }
        return _DarkWorldPreview;
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

    private Camera2D? _Camera2D;
    public Camera2D Camera2D {
      get {
        if (_Camera2D == null) {
          _Camera2D = parent.GetNode<Camera2D>("Camera2D");
        }
        return _Camera2D;
      }
    }

    private WorldEnvironment? _Camera2D_WorldEnvironment;
    public WorldEnvironment Camera2D_WorldEnvironment {
      get {
        if (_Camera2D_WorldEnvironment == null) {
          _Camera2D_WorldEnvironment = parent.GetNode<WorldEnvironment>("Camera2D/WorldEnvironment");
        }
        return _Camera2D_WorldEnvironment;
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

    private HeadsUpDisplay? _StaticCanvasLayer;
    public HeadsUpDisplay StaticCanvasLayer {
      get {
        if (_StaticCanvasLayer == null) {
          _StaticCanvasLayer = parent.GetNode<HeadsUpDisplay>("StaticCanvasLayer");
        }
        return _StaticCanvasLayer;
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

    private VortexGun? _VortexGun;
    public VortexGun VortexGun {
      get {
        if (_VortexGun == null) {
          _VortexGun = parent.GetNode<VortexGun>("VortexGun");
        }
        return _VortexGun;
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

    private DialogTrigger? _DialogTriggers_LavaDialogTrigger;
    public DialogTrigger DialogTriggers_LavaDialogTrigger {
      get {
        if (_DialogTriggers_LavaDialogTrigger == null) {
          _DialogTriggers_LavaDialogTrigger = parent.GetNode<DialogTrigger>("DialogTriggers/LavaDialogTrigger");
        }
        return _DialogTriggers_LavaDialogTrigger;
      }
    }

    private DialogTrigger? _DialogTriggers_CannonDialogTrigger;
    public DialogTrigger DialogTriggers_CannonDialogTrigger {
      get {
        if (_DialogTriggers_CannonDialogTrigger == null) {
          _DialogTriggers_CannonDialogTrigger = parent.GetNode<DialogTrigger>("DialogTriggers/CannonDialogTrigger");
        }
        return _DialogTriggers_CannonDialogTrigger;
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

    private SaveStation? _SaveStation;
    public SaveStation SaveStation {
      get {
        if (_SaveStation == null) {
          _SaveStation = parent.GetNode<SaveStation>("SaveStation");
        }
        return _SaveStation;
      }
    }

    private FakeBlub? _FakeBlub;
    public FakeBlub FakeBlub {
      get {
        if (_FakeBlub == null) {
          _FakeBlub = parent.GetNode<FakeBlub>("FakeBlub");
        }
        return _FakeBlub;
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
