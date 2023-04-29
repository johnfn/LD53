using Godot;
public partial class DialogTrigger : Node2D {
  public static DialogTrigger New() {
    return GD.Load<PackedScene>("res://dialog_trigger.tscn").Instantiate<DialogTrigger>();
  }
  public DialogTrigger() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class DialogTriggerNodes {
    DialogTrigger parent;
    public DialogTriggerNodes(DialogTrigger parent) {
      this.parent = parent;
    }
    private Area2D? _Area;
    public Area2D Area {
      get {
        if (_Area == null) {
          _Area = parent.GetNode<Area2D>("Area");
        }
        return _Area;
      }
    }

    private CollisionShape2D? _Area_Shape;
    public CollisionShape2D Area_Shape {
      get {
        if (_Area_Shape == null) {
          _Area_Shape = parent.GetNode<CollisionShape2D>("Area/Shape");
        }
        return _Area_Shape;
      }
    }

  }

  public DialogTriggerNodes? _Nodes;
  public DialogTriggerNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new DialogTriggerNodes(this);
      }
      return _Nodes;
    }
  }
}
