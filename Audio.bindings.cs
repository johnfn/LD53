using Godot;
public partial class Audio : Node2D {
  public static Audio New() {
    return GD.Load<PackedScene>("res://audio.tscn").Instantiate<Audio>();
  }
  public Audio() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class AudioNodes {
    Audio parent;
    public AudioNodes(Audio parent) {
      this.parent = parent;
    }
    private AudioStreamPlayer? _Chirp;
    public AudioStreamPlayer Chirp {
      get {
        if (_Chirp == null) {
          _Chirp = parent.GetNode<AudioStreamPlayer>("Chirp");
        }
        return _Chirp;
      }
    }

    private AudioStreamPlayer? _ChirpDone;
    public AudioStreamPlayer ChirpDone {
      get {
        if (_ChirpDone == null) {
          _ChirpDone = parent.GetNode<AudioStreamPlayer>("ChirpDone");
        }
        return _ChirpDone;
      }
    }

    private AudioStreamPlayer? _Warp;
    public AudioStreamPlayer Warp {
      get {
        if (_Warp == null) {
          _Warp = parent.GetNode<AudioStreamPlayer>("Warp");
        }
        return _Warp;
      }
    }

    private AudioStreamPlayer? _CreatePortal;
    public AudioStreamPlayer CreatePortal {
      get {
        if (_CreatePortal == null) {
          _CreatePortal = parent.GetNode<AudioStreamPlayer>("CreatePortal");
        }
        return _CreatePortal;
      }
    }

    private AudioStreamPlayer? _ClosePortal;
    public AudioStreamPlayer ClosePortal {
      get {
        if (_ClosePortal == null) {
          _ClosePortal = parent.GetNode<AudioStreamPlayer>("ClosePortal");
        }
        return _ClosePortal;
      }
    }

  }

  public AudioNodes? _Nodes;
  public AudioNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new AudioNodes(this);
      }
      return _Nodes;
    }
  }
}
