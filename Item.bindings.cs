using Godot;
public partial class Item : Node2D {
  public static Item New() {
    return GD.Load<PackedScene>("res://item.tscn").Instantiate<Item>();
  }
  public Item() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class ItemNodes {
    Item parent;
    public ItemNodes(Item parent) {
      this.parent = parent;
    }
    private Sprite2D? _FakeGlow;
    public Sprite2D FakeGlow {
      get {
        if (_FakeGlow == null) {
          _FakeGlow = parent.GetNode<Sprite2D>("FakeGlow");
        }
        return _FakeGlow;
      }
    }

    private Sprite2D? _Item_;
    public Sprite2D Item_ {
      get {
        if (_Item_ == null) {
          _Item_ = parent.GetNode<Sprite2D>("Item");
        }
        return _Item_;
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

    public void AnimationPlayer_PlayBobble() {
      AnimationPlayer.Play("Bobble");
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

  }

  public ItemNodes? _Nodes;
  public ItemNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new ItemNodes(this);
      }
      return _Nodes;
    }
  }
}
