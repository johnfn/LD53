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

    private Sprite2D? _SimpleBackgroundOutline;
    public Sprite2D SimpleBackgroundOutline {
      get {
        if (_SimpleBackgroundOutline == null) {
          _SimpleBackgroundOutline = parent.GetNode<Sprite2D>("SimpleBackgroundOutline");
        }
        return _SimpleBackgroundOutline;
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

    private Sprite2D? _SourceBackground;
    public Sprite2D SourceBackground {
      get {
        if (_SourceBackground == null) {
          _SourceBackground = parent.GetNode<Sprite2D>("SourceBackground");
        }
        return _SourceBackground;
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
