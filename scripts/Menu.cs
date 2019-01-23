using Godot;
using System;

public class Menu : Node {
  [Signal]
  public delegate void starGame();

  public void _on_Button_pressed() {
    EmitSignal(nameof(starGame));
  }
}