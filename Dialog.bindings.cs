using Godot;
public partial class Dialog : PanelContainer {
  public static Dialog New() {
    return GD.Load<PackedScene>("res://dialog.tscn").Instantiate<Dialog>();
  }
  public Dialog() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class DialogNodes {
    Dialog parent;
    public DialogNodes(Dialog parent) {
      this.parent = parent;
    }
    private MarginContainer? _MarginContainer;
    public MarginContainer MarginContainer {
      get {
        if (_MarginContainer == null) {
          _MarginContainer = parent.GetNode<MarginContainer>("MarginContainer");
        }
        return _MarginContainer;
      }
    }

    private Label? _MarginContainer_Label;
    public Label MarginContainer_Label {
      get {
        if (_MarginContainer_Label == null) {
          _MarginContainer_Label = parent.GetNode<Label>("MarginContainer/Label");
        }
        return _MarginContainer_Label;
      }
    }

  }

  public DialogNodes? _Nodes;
  public DialogNodes Nodes {
    get {
      if (_Nodes == null) {
        _Nodes = new DialogNodes(this);
      }
      return _Nodes;
    }
  }
}
