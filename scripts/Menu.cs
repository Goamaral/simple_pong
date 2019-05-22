using Godot;
using System;

public class Menu : Node {
  public void _on_Button_pressed() {
    Store.GotoScene(Store.SceneType.Game);
  }
}
