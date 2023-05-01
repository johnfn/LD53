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

    private Sprite2D? _GlowHacks_LinearGradient2;
    public Sprite2D GlowHacks_LinearGradient2 {
      get {
        if (_GlowHacks_LinearGradient2 == null) {
          _GlowHacks_LinearGradient2 = parent.GetNode<Sprite2D>("GlowHacks/LinearGradient2");
        }
        return _GlowHacks_LinearGradient2;
      }
    }

    private Sprite2D? _GlowHacks_LinearGradient3;
    public Sprite2D GlowHacks_LinearGradient3 {
      get {
        if (_GlowHacks_LinearGradient3 == null) {
          _GlowHacks_LinearGradient3 = parent.GetNode<Sprite2D>("GlowHacks/LinearGradient3");
        }
        return _GlowHacks_LinearGradient3;
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

    private Sprite2D? _GlowHacks_CrystalGlow;
    public Sprite2D GlowHacks_CrystalGlow {
      get {
        if (_GlowHacks_CrystalGlow == null) {
          _GlowHacks_CrystalGlow = parent.GetNode<Sprite2D>("GlowHacks/CrystalGlow");
        }
        return _GlowHacks_CrystalGlow;
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

    private GpuParticles2D? _GlowHacks_LavaParticles2;
    public GpuParticles2D GlowHacks_LavaParticles2 {
      get {
        if (_GlowHacks_LavaParticles2 == null) {
          _GlowHacks_LavaParticles2 = parent.GetNode<GpuParticles2D>("GlowHacks/LavaParticles2");
        }
        return _GlowHacks_LavaParticles2;
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

    private GpuParticles2D? _GlowHacks_LavaParticles3;
    public GpuParticles2D GlowHacks_LavaParticles3 {
      get {
        if (_GlowHacks_LavaParticles3 == null) {
          _GlowHacks_LavaParticles3 = parent.GetNode<GpuParticles2D>("GlowHacks/LavaParticles3");
        }
        return _GlowHacks_LavaParticles3;
      }
    }

    private Node2D? _GlowHacks_LavaGlow;
    public Node2D GlowHacks_LavaGlow {
      get {
        if (_GlowHacks_LavaGlow == null) {
          _GlowHacks_LavaGlow = parent.GetNode<Node2D>("GlowHacks/LavaGlow");
        }
        return _GlowHacks_LavaGlow;
      }
    }

    private Sprite2D? _GlowHacks_LavaGlow_LinearGradient;
    public Sprite2D GlowHacks_LavaGlow_LinearGradient {
      get {
        if (_GlowHacks_LavaGlow_LinearGradient == null) {
          _GlowHacks_LavaGlow_LinearGradient = parent.GetNode<Sprite2D>("GlowHacks/LavaGlow/LinearGradient");
        }
        return _GlowHacks_LavaGlow_LinearGradient;
      }
    }

    private GpuParticles2D? _GlowHacks_LavaGlow_LavaParticles2;
    public GpuParticles2D GlowHacks_LavaGlow_LavaParticles2 {
      get {
        if (_GlowHacks_LavaGlow_LavaParticles2 == null) {
          _GlowHacks_LavaGlow_LavaParticles2 = parent.GetNode<GpuParticles2D>("GlowHacks/LavaGlow/LavaParticles2");
        }
        return _GlowHacks_LavaGlow_LavaParticles2;
      }
    }

    private Node2D? _GlowHacks_LavaGlow2;
    public Node2D GlowHacks_LavaGlow2 {
      get {
        if (_GlowHacks_LavaGlow2 == null) {
          _GlowHacks_LavaGlow2 = parent.GetNode<Node2D>("GlowHacks/LavaGlow2");
        }
        return _GlowHacks_LavaGlow2;
      }
    }

    private Sprite2D? _GlowHacks_LavaGlow2_LinearGradient;
    public Sprite2D GlowHacks_LavaGlow2_LinearGradient {
      get {
        if (_GlowHacks_LavaGlow2_LinearGradient == null) {
          _GlowHacks_LavaGlow2_LinearGradient = parent.GetNode<Sprite2D>("GlowHacks/LavaGlow2/LinearGradient");
        }
        return _GlowHacks_LavaGlow2_LinearGradient;
      }
    }

    private GpuParticles2D? _GlowHacks_LavaGlow2_LavaParticles2;
    public GpuParticles2D GlowHacks_LavaGlow2_LavaParticles2 {
      get {
        if (_GlowHacks_LavaGlow2_LavaParticles2 == null) {
          _GlowHacks_LavaGlow2_LavaParticles2 = parent.GetNode<GpuParticles2D>("GlowHacks/LavaGlow2/LavaParticles2");
        }
        return _GlowHacks_LavaGlow2_LavaParticles2;
      }
    }

    private Node2D? _GlowHacks_LavaGlow3;
    public Node2D GlowHacks_LavaGlow3 {
      get {
        if (_GlowHacks_LavaGlow3 == null) {
          _GlowHacks_LavaGlow3 = parent.GetNode<Node2D>("GlowHacks/LavaGlow3");
        }
        return _GlowHacks_LavaGlow3;
      }
    }

    private Sprite2D? _GlowHacks_LavaGlow3_LinearGradient;
    public Sprite2D GlowHacks_LavaGlow3_LinearGradient {
      get {
        if (_GlowHacks_LavaGlow3_LinearGradient == null) {
          _GlowHacks_LavaGlow3_LinearGradient = parent.GetNode<Sprite2D>("GlowHacks/LavaGlow3/LinearGradient");
        }
        return _GlowHacks_LavaGlow3_LinearGradient;
      }
    }

    private GpuParticles2D? _GlowHacks_LavaGlow3_LavaParticles2;
    public GpuParticles2D GlowHacks_LavaGlow3_LavaParticles2 {
      get {
        if (_GlowHacks_LavaGlow3_LavaParticles2 == null) {
          _GlowHacks_LavaGlow3_LavaParticles2 = parent.GetNode<GpuParticles2D>("GlowHacks/LavaGlow3/LavaParticles2");
        }
        return _GlowHacks_LavaGlow3_LavaParticles2;
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

    private Node2D? _Mailboxes;
    public Node2D Mailboxes {
      get {
        if (_Mailboxes == null) {
          _Mailboxes = parent.GetNode<Node2D>("Mailboxes");
        }
        return _Mailboxes;
      }
    }

    private Node2D? _Mailboxes_Mailbox_Target;
    public Node2D Mailboxes_Mailbox_Target {
      get {
        if (_Mailboxes_Mailbox_Target == null) {
          _Mailboxes_Mailbox_Target = parent.GetNode<Node2D>("Mailboxes/Mailbox/Target");
        }
        return _Mailboxes_Mailbox_Target;
      }
    }

    private Node2D? _Mailboxes_Mailbox2_Target;
    public Node2D Mailboxes_Mailbox2_Target {
      get {
        if (_Mailboxes_Mailbox2_Target == null) {
          _Mailboxes_Mailbox2_Target = parent.GetNode<Node2D>("Mailboxes/Mailbox2/Target");
        }
        return _Mailboxes_Mailbox2_Target;
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

    private Sprite2D? _BackgroundCanvasLayer_Sky2;
    public Sprite2D BackgroundCanvasLayer_Sky2 {
      get {
        if (_BackgroundCanvasLayer_Sky2 == null) {
          _BackgroundCanvasLayer_Sky2 = parent.GetNode<Sprite2D>("BackgroundCanvasLayer/Sky2");
        }
        return _BackgroundCanvasLayer_Sky2;
      }
    }

    private Sprite2D? _BackgroundCanvasLayer_Sky3;
    public Sprite2D BackgroundCanvasLayer_Sky3 {
      get {
        if (_BackgroundCanvasLayer_Sky3 == null) {
          _BackgroundCanvasLayer_Sky3 = parent.GetNode<Sprite2D>("BackgroundCanvasLayer/Sky3");
        }
        return _BackgroundCanvasLayer_Sky3;
      }
    }

    private GpuParticles2D? _BackgroundCanvasLayer_RandomParticles;
    public GpuParticles2D BackgroundCanvasLayer_RandomParticles {
      get {
        if (_BackgroundCanvasLayer_RandomParticles == null) {
          _BackgroundCanvasLayer_RandomParticles = parent.GetNode<GpuParticles2D>("BackgroundCanvasLayer/RandomParticles");
        }
        return _BackgroundCanvasLayer_RandomParticles;
      }
    }

    private Node2D? _SaveStations;
    public Node2D SaveStations {
      get {
        if (_SaveStations == null) {
          _SaveStations = parent.GetNode<Node2D>("SaveStations");
        }
        return _SaveStations;
      }
    }

    private GpuParticles2D? _SplashParticle;
    public GpuParticles2D SplashParticle {
      get {
        if (_SplashParticle == null) {
          _SplashParticle = parent.GetNode<GpuParticles2D>("SplashParticle");
        }
        return _SplashParticle;
      }
    }

    private Node2D? _LinkRemovers;
    public Node2D LinkRemovers {
      get {
        if (_LinkRemovers == null) {
          _LinkRemovers = parent.GetNode<Node2D>("LinkRemovers");
        }
        return _LinkRemovers;
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

    private Mailbox? _Mailboxes_Mailbox;
    public Mailbox Mailboxes_Mailbox {
      get {
        if (_Mailboxes_Mailbox == null) {
          _Mailboxes_Mailbox = parent.GetNode<Mailbox>("Mailboxes/Mailbox");
        }
        return _Mailboxes_Mailbox;
      }
    }

    private Mailbox? _Mailboxes_Mailbox2;
    public Mailbox Mailboxes_Mailbox2 {
      get {
        if (_Mailboxes_Mailbox2 == null) {
          _Mailboxes_Mailbox2 = parent.GetNode<Mailbox>("Mailboxes/Mailbox2");
        }
        return _Mailboxes_Mailbox2;
      }
    }

    private Mailbox? _Mailboxes_Mailbox3;
    public Mailbox Mailboxes_Mailbox3 {
      get {
        if (_Mailboxes_Mailbox3 == null) {
          _Mailboxes_Mailbox3 = parent.GetNode<Mailbox>("Mailboxes/Mailbox3");
        }
        return _Mailboxes_Mailbox3;
      }
    }

    private Mailbox? _Mailboxes_Mailbox5;
    public Mailbox Mailboxes_Mailbox5 {
      get {
        if (_Mailboxes_Mailbox5 == null) {
          _Mailboxes_Mailbox5 = parent.GetNode<Mailbox>("Mailboxes/Mailbox5");
        }
        return _Mailboxes_Mailbox5;
      }
    }

    private Mailbox? _Mailboxes_Mailbox4;
    public Mailbox Mailboxes_Mailbox4 {
      get {
        if (_Mailboxes_Mailbox4 == null) {
          _Mailboxes_Mailbox4 = parent.GetNode<Mailbox>("Mailboxes/Mailbox4");
        }
        return _Mailboxes_Mailbox4;
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

    private DialogTrigger? _DialogTriggers_CannonDialogTrigger2;
    public DialogTrigger DialogTriggers_CannonDialogTrigger2 {
      get {
        if (_DialogTriggers_CannonDialogTrigger2 == null) {
          _DialogTriggers_CannonDialogTrigger2 = parent.GetNode<DialogTrigger>("DialogTriggers/CannonDialogTrigger2");
        }
        return _DialogTriggers_CannonDialogTrigger2;
      }
    }

    private DialogTrigger? _DialogTriggers_CannonDialogTrigger3;
    public DialogTrigger DialogTriggers_CannonDialogTrigger3 {
      get {
        if (_DialogTriggers_CannonDialogTrigger3 == null) {
          _DialogTriggers_CannonDialogTrigger3 = parent.GetNode<DialogTrigger>("DialogTriggers/CannonDialogTrigger3");
        }
        return _DialogTriggers_CannonDialogTrigger3;
      }
    }

    private DialogTrigger? _DialogTriggers_CantMakeIt;
    public DialogTrigger DialogTriggers_CantMakeIt {
      get {
        if (_DialogTriggers_CantMakeIt == null) {
          _DialogTriggers_CantMakeIt = parent.GetNode<DialogTrigger>("DialogTriggers/CantMakeIt");
        }
        return _DialogTriggers_CantMakeIt;
      }
    }

    private DialogTrigger? _DialogTriggers_LostLink;
    public DialogTrigger DialogTriggers_LostLink {
      get {
        if (_DialogTriggers_LostLink == null) {
          _DialogTriggers_LostLink = parent.GetNode<DialogTrigger>("DialogTriggers/LostLink");
        }
        return _DialogTriggers_LostLink;
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

    private SaveStation? _SaveStations_SaveStation;
    public SaveStation SaveStations_SaveStation {
      get {
        if (_SaveStations_SaveStation == null) {
          _SaveStations_SaveStation = parent.GetNode<SaveStation>("SaveStations/SaveStation");
        }
        return _SaveStations_SaveStation;
      }
    }

    private SaveStation? _SaveStations_SaveStation2;
    public SaveStation SaveStations_SaveStation2 {
      get {
        if (_SaveStations_SaveStation2 == null) {
          _SaveStations_SaveStation2 = parent.GetNode<SaveStation>("SaveStations/SaveStation2");
        }
        return _SaveStations_SaveStation2;
      }
    }

    private SaveStation? _SaveStations_SaveStation5;
    public SaveStation SaveStations_SaveStation5 {
      get {
        if (_SaveStations_SaveStation5 == null) {
          _SaveStations_SaveStation5 = parent.GetNode<SaveStation>("SaveStations/SaveStation5");
        }
        return _SaveStations_SaveStation5;
      }
    }

    private SaveStation? _SaveStations_SaveStation3;
    public SaveStation SaveStations_SaveStation3 {
      get {
        if (_SaveStations_SaveStation3 == null) {
          _SaveStations_SaveStation3 = parent.GetNode<SaveStation>("SaveStations/SaveStation3");
        }
        return _SaveStations_SaveStation3;
      }
    }

    private SaveStation? _SaveStations_SaveStation4;
    public SaveStation SaveStations_SaveStation4 {
      get {
        if (_SaveStations_SaveStation4 == null) {
          _SaveStations_SaveStation4 = parent.GetNode<SaveStation>("SaveStations/SaveStation4");
        }
        return _SaveStations_SaveStation4;
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

    private Item? _Item;
    public Item Item {
      get {
        if (_Item == null) {
          _Item = parent.GetNode<Item>("Item");
        }
        return _Item;
      }
    }

    private LinkRemover? _LinkRemovers_LinkRemover;
    public LinkRemover LinkRemovers_LinkRemover {
      get {
        if (_LinkRemovers_LinkRemover == null) {
          _LinkRemovers_LinkRemover = parent.GetNode<LinkRemover>("LinkRemovers/LinkRemover");
        }
        return _LinkRemovers_LinkRemover;
      }
    }

    private LinkRemover? _LinkRemovers_LinkRemover2;
    public LinkRemover LinkRemovers_LinkRemover2 {
      get {
        if (_LinkRemovers_LinkRemover2 == null) {
          _LinkRemovers_LinkRemover2 = parent.GetNode<LinkRemover>("LinkRemovers/LinkRemover2");
        }
        return _LinkRemovers_LinkRemover2;
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
