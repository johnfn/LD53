using Godot;
public partial class Blub : CharacterBody2D {
  public static Blub New() {
    return GD.Load<PackedScene>("res://blub.tscn").Instantiate<Blub>();
  }
  public Blub() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class BlubNodes {
    Blub parent;
    public BlubNodes(Blub parent) {
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

    private Sprite2D? _GraphicAlt;
    public Sprite2D GraphicAlt {
      get {
        if (_GraphicAlt == null) {
          _GraphicAlt = parent.GetNode<Sprite2D>("GraphicAlt");
        }
        return _GraphicAlt;
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

    private Area2D? _InteractionArea;
    public Area2D InteractionArea {
      get {
        if (_InteractionArea == null) {
          _InteractionArea = parent.GetNode<Area2D>("InteractionArea");
        }
        return _InteractionArea;
      }
    }

    private CollisionShape2D? _InteractionArea_Shape;
    public CollisionShape2D InteractionArea_Shape {
      get {
        if (_InteractionArea_Shape == null) {
          _InteractionArea_Shape = parent.GetNode<CollisionShape2D>("InteractionArea/Shape");
        }
        return _InteractionArea_Shape;
      }
    }

    private Node2D? _OverheadText;
    public Node2D OverheadText {
      get {
        if (_OverheadText == null) {
          _OverheadText = parent.GetNode<Node2D>("OverheadText");
        }
        return _OverheadText;
      }
    }

    private Label? _OverheadText_Text;
    public Label OverheadText_Text {
      get {
        if (_OverheadText_Text == null) {
          _OverheadText_Text = parent.GetNode<Label>("OverheadText/Text");
        }
        return _OverheadText_Text;
      }
    }

    private AnimationPlayer? _OverheadText_AnimationPlayer;
    public AnimationPlayer OverheadText_AnimationPlayer {
      get {
        if (_OverheadText_AnimationPlayer == null) {
          _OverheadText_AnimationPlayer = parent.GetNode<AnimationPlayer>("OverheadText/AnimationPlayer");
        }
        return _OverheadText_AnimationPlayer;
      }
    }

    public void OverheadText_AnimationPlayer_PlayPlayText() {
      OverheadText_AnimationPlayer.Play("PlayText");
    }
    public void OverheadText_AnimationPlayer_PlayRESET() {
      OverheadText_AnimationPlayer.Play("RESET");
    }
  }

  public BlubNodes? _Nodes;
  public BlubNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new BlubNodes(this);
      }
      return _Nodes;
    }
  }
}
