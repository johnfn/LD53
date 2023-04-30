using Godot;
public partial class Aim : Node2D {
  public static Aim New() {
    return GD.Load<PackedScene>("res://aim.tscn").Instantiate<Aim>();
  }
  public Aim() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class AimNodes {
    Aim parent;
    public AimNodes(Aim parent) {
      this.parent = parent;
    }
    private Sprite2D? _Reticle;
    public Sprite2D Reticle {
      get {
        if (_Reticle == null) {
          _Reticle = parent.GetNode<Sprite2D>("Reticle");
        }
        return _Reticle;
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

    public void AnimationPlayer_PlayReticle() {
      AnimationPlayer.Play("Reticle");
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

  }

  public AimNodes? _Nodes;
  public AimNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new AimNodes(this);
      }
      return _Nodes;
    }
  }
}
