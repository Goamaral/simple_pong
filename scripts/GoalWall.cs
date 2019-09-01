using Godot;
using System;

public class GoalWall : Area2D {

  // HELPER METHODS
  public void GoToNextScene() {
    Store.GotoScene(Store.SceneType.Scoreboard);
  }

  // TRIGGER METHODS
  public void _on_Left_body_entered(Godot.Object body) {
    Store.player2Score += 1;
    GoToNextScene();
  }

  public void _on_Right_body_entered(Godot.Object body) {
    Store.player1Score += 1;
    GoToNextScene();
  }
}