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
