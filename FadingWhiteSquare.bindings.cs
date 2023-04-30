using Godot;
public partial class FadingWhiteSquare : Sprite2D {
  public static FadingWhiteSquare New() {
    return GD.Load<PackedScene>("res://fading_white_square.tscn").Instantiate<FadingWhiteSquare>();
  }
  public FadingWhiteSquare() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class FadingWhiteSquareNodes {
    FadingWhiteSquare parent;
    public FadingWhiteSquareNodes(FadingWhiteSquare parent) {
      this.parent = parent;
    }
  }

  public FadingWhiteSquareNodes? _Nodes;
  public FadingWhiteSquareNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new FadingWhiteSquareNodes(this);
      }
      return _Nodes;
    }
  }
}
