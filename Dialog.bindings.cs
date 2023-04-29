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
    private VBoxContainer? _VBoxContainer;
    public VBoxContainer VBoxContainer {
      get {
        if (_VBoxContainer == null) {
          _VBoxContainer = parent.GetNode<VBoxContainer>("VBoxContainer");
        }
        return _VBoxContainer;
      }
    }

    private MarginContainer? _VBoxContainer_MarginContainer;
    public MarginContainer VBoxContainer_MarginContainer {
      get {
        if (_VBoxContainer_MarginContainer == null) {
          _VBoxContainer_MarginContainer = parent.GetNode<MarginContainer>("VBoxContainer/MarginContainer");
        }
        return _VBoxContainer_MarginContainer;
      }
    }

    private Label? _VBoxContainer_MarginContainer_Label;
    public Label VBoxContainer_MarginContainer_Label {
      get {
        if (_VBoxContainer_MarginContainer_Label == null) {
          _VBoxContainer_MarginContainer_Label = parent.GetNode<Label>("VBoxContainer/MarginContainer/Label");
        }
        return _VBoxContainer_MarginContainer_Label;
      }
    }

    private Button? _VBoxContainer_Button;
    public Button VBoxContainer_Button {
      get {
        if (_VBoxContainer_Button == null) {
          _VBoxContainer_Button = parent.GetNode<Button>("VBoxContainer/Button");
        }
        return _VBoxContainer_Button;
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
