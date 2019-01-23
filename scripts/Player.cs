using Godot;
using System;

public class Player : KinematicBody2D {
  [Export]
  public int player_id = 0;

  public override void _PhysicsProcess(float delta) {
    bool is_up = Input.IsActionPressed(String.Format("player_{0}_up", player_id));

    if (is_up) {
      MoveAndCollide(new Vector2(0, -5));
    } else {
      MoveAndCollide(new Vector2(0, 5));
    }
  }
}
