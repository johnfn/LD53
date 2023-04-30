using Godot;
public partial class FakeBlub : Node2D {
  public static FakeBlub New() {
    return GD.Load<PackedScene>("res://fake_blub.tscn").Instantiate<FakeBlub>();
  }
  public FakeBlub() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class FakeBlubNodes {
    FakeBlub parent;
    public FakeBlubNodes(FakeBlub parent) {
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

  }

  public FakeBlubNodes? _Nodes;
  public FakeBlubNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new FakeBlubNodes(this);
      }
      return _Nodes;
    }
  }
}
