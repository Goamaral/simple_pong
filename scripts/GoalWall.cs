using Godot;
using System;

public class GoalWall : Area2D {
  public void _on_Left_body_entered(Godot.Object body) {
    Main.player1Score += 1;
    printScoreboard();
  }

  public void _on_Right_body_entered(Godot.Object body) {
    Main.player2Score += 1;
    printScoreboard();
  }

  public void printScoreboard() {
    Console.WriteLine(Main.player1Score + " - " + Main.player2Score);
  }
}