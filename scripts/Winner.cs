using Godot;
using System;

public class Winner : Node {
  public override void _Ready() {
    Label winner_value = (Label)GetNode("VBoxContainer/WinnerValue");
    winner_value.SetText("Player " + Store.Winner() + " won!");
  }

  private void _on_Button_pressed() {
    Store.ScoreReset();
    Store.GotoScene(Store.SceneType.Menu);
  }
}
