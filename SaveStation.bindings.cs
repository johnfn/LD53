using Godot;
public partial class SaveStation : Node2D {
  public static SaveStation New() {
    return GD.Load<PackedScene>("res://save_station.tscn").Instantiate<SaveStation>();
  }
  public SaveStation() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class SaveStationNodes {
    SaveStation parent;
    public SaveStationNodes(SaveStation parent) {
      this.parent = parent;
    }
    private Sprite2D? _FakeGlow3;
    public Sprite2D FakeGlow3 {
      get {
        if (_FakeGlow3 == null) {
          _FakeGlow3 = parent.GetNode<Sprite2D>("FakeGlow3");
        }
        return _FakeGlow3;
      }
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

    private Area2D? _Area2D;
    public Area2D Area2D {
      get {
        if (_Area2D == null) {
          _Area2D = parent.GetNode<Area2D>("Area2D");
        }
        return _Area2D;
      }
    }

    private CollisionShape2D? _Area2D_CollisionShape2D;
    public CollisionShape2D Area2D_CollisionShape2D {
      get {
        if (_Area2D_CollisionShape2D == null) {
          _Area2D_CollisionShape2D = parent.GetNode<CollisionShape2D>("Area2D/CollisionShape2D");
        }
        return _Area2D_CollisionShape2D;
      }
    }

    private StaticBody2D? _StaticBody2D;
    public StaticBody2D StaticBody2D {
      get {
        if (_StaticBody2D == null) {
          _StaticBody2D = parent.GetNode<StaticBody2D>("StaticBody2D");
        }
        return _StaticBody2D;
      }
    }

    private CollisionShape2D? _StaticBody2D_CollisionShape2D;
    public CollisionShape2D StaticBody2D_CollisionShape2D {
      get {
        if (_StaticBody2D_CollisionShape2D == null) {
          _StaticBody2D_CollisionShape2D = parent.GetNode<CollisionShape2D>("StaticBody2D/CollisionShape2D");
        }
        return _StaticBody2D_CollisionShape2D;
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

    public void AnimationPlayer_PlayPulse() {
      AnimationPlayer.Play("Pulse");
    }
    public void AnimationPlayer_PlayRESET() {
      AnimationPlayer.Play("RESET");
    }
    private GpuParticles2D? _SaveStationParticles;
    public GpuParticles2D SaveStationParticles {
      get {
        if (_SaveStationParticles == null) {
          _SaveStationParticles = parent.GetNode<GpuParticles2D>("SaveStationParticles");
        }
        return _SaveStationParticles;
      }
    }

  }

  public SaveStationNodes? _Nodes;
  public SaveStationNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new SaveStationNodes(this);
      }
      return _Nodes;
    }
  }
}
