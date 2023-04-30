using Godot;
public partial class Mailbox : Node2D {
  public static Mailbox New() {
    return GD.Load<PackedScene>("res://mailbox.tscn").Instantiate<Mailbox>();
  }
  public Mailbox() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class MailboxNodes {
    Mailbox parent;
    public MailboxNodes(Mailbox parent) {
      this.parent = parent;
    }
    private Sprite2D? _MailboxGraphic;
    public Sprite2D MailboxGraphic {
      get {
        if (_MailboxGraphic == null) {
          _MailboxGraphic = parent.GetNode<Sprite2D>("MailboxGraphic");
        }
        return _MailboxGraphic;
      }
    }

    private Sprite2D? _RippleEffect;
    public Sprite2D RippleEffect {
      get {
        if (_RippleEffect == null) {
          _RippleEffect = parent.GetNode<Sprite2D>("RippleEffect");
        }
        return _RippleEffect;
      }
    }

    private Sprite2D? _SimpleBackground;
    public Sprite2D SimpleBackground {
      get {
        if (_SimpleBackground == null) {
          _SimpleBackground = parent.GetNode<Sprite2D>("SimpleBackground");
        }
        return _SimpleBackground;
      }
    }

    private Area2D? _SimpleBackground_Area2D;
    public Area2D SimpleBackground_Area2D {
      get {
        if (_SimpleBackground_Area2D == null) {
          _SimpleBackground_Area2D = parent.GetNode<Area2D>("SimpleBackground/Area2D");
        }
        return _SimpleBackground_Area2D;
      }
    }

    private CollisionShape2D? _SimpleBackground_Area2D_CollisionShape2D;
    public CollisionShape2D SimpleBackground_Area2D_CollisionShape2D {
      get {
        if (_SimpleBackground_Area2D_CollisionShape2D == null) {
          _SimpleBackground_Area2D_CollisionShape2D = parent.GetNode<CollisionShape2D>("SimpleBackground/Area2D/CollisionShape2D");
        }
        return _SimpleBackground_Area2D_CollisionShape2D;
      }
    }

    private Sprite2D? _SourceBackground;
    public Sprite2D SourceBackground {
      get {
        if (_SourceBackground == null) {
          _SourceBackground = parent.GetNode<Sprite2D>("SourceBackground");
        }
        return _SourceBackground;
      }
    }

    private Area2D? _SourceBackground_Area2D;
    public Area2D SourceBackground_Area2D {
      get {
        if (_SourceBackground_Area2D == null) {
          _SourceBackground_Area2D = parent.GetNode<Area2D>("SourceBackground/Area2D");
        }
        return _SourceBackground_Area2D;
      }
    }

    private CollisionShape2D? _SourceBackground_Area2D_CollisionShape2D;
    public CollisionShape2D SourceBackground_Area2D_CollisionShape2D {
      get {
        if (_SourceBackground_Area2D_CollisionShape2D == null) {
          _SourceBackground_Area2D_CollisionShape2D = parent.GetNode<CollisionShape2D>("SourceBackground/Area2D/CollisionShape2D");
        }
        return _SourceBackground_Area2D_CollisionShape2D;
      }
    }

    private AnimationPlayer? _AnimationPlayer;
    public AnimationPlayer AnimationPlayer {
      get {
        if (_AnimationPlayer == null) {
          _AnimationPlayer = parent.GetNode<AnimationPlayer>("AnimationPlayer");
        }
        return _AnimationPlayer;
      }
    }

    public void AnimationPlayer_PlayPulseBorder() {
      AnimationPlayer.Play("PulseBorder");
    }
  }

  public MailboxNodes? _Nodes;
  public MailboxNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new MailboxNodes(this);
      }
      return _Nodes;
    }
  }
}
