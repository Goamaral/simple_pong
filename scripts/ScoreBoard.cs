using Godot;
using System;

public class ScoreBoard : Node {
  public override void _Ready() {
    Label score_value = (Label)GetNode("VBoxContainer/ScoreValue");
    score_value.SetText(Store.Score());
  }

  private void _on_Button_pressed() {
    Store.GotoScene(Store.SceneType.Game);
  }
}