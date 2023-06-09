using Godot;
public partial class HeadsUpDisplay : CanvasLayer {
  public static HeadsUpDisplay New() {
    return GD.Load<PackedScene>("res://static_canvas_layer.tscn").Instantiate<HeadsUpDisplay>();
  }
  public HeadsUpDisplay() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class HeadsUpDisplayNodes {
    HeadsUpDisplay parent;
    public HeadsUpDisplayNodes(HeadsUpDisplay parent) {
      this.parent = parent;
    }
    private Label? _EActionLabel;
    public Label EActionLabel {
      get {
        if (_EActionLabel == null) {
          _EActionLabel = parent.GetNode<Label>("EActionLabel");
        }
        return _EActionLabel;
      }
    }

    private Label? _RActionLabel;
    public Label RActionLabel {
      get {
        if (_RActionLabel == null) {
          _RActionLabel = parent.GetNode<Label>("RActionLabel");
        }
        return _RActionLabel;
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

    public void AnimationPlayer_PlayRESET() {
      AnimationPlayer.Play("RESET");
    }
    public void AnimationPlayer_PlayShowLabel() {
      AnimationPlayer.Play("ShowLabel");
    }
    private Dialog? _Dialog;
    public Dialog Dialog {
      get {
        if (_Dialog == null) {
          _Dialog = parent.GetNode<Dialog>("Dialog");
        }
        return _Dialog;
      }
    }

  }

  public HeadsUpDisplayNodes? _Nodes;
  public HeadsUpDisplayNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new HeadsUpDisplayNodes(this);
      }
      return _Nodes;
    }
  }
}
