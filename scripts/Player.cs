using Godot;
using System;

public class Player : KinematicBody2D {
  public int player_id = 0;

  public override void _Ready() {
    string[] path_parts = this.GetPath().ToString().Split("/");
    player_id = path_parts[path_parts.Length - 1].Split("Player")[0].ToInt();
  }

  public override void _PhysicsProcess(float delta) {
    bool is_up = Input.IsActionPressed(String.Format("player_{0}_up", player_id));
    bool is_down = Input.IsActionPressed(String.Format("player_{0}_down", player_id));

    if (is_up) {
      MoveAndCollide(new Vector2(0, -5));
    } else if(is_down) {
      MoveAndCollide(new Vector2(0, 5));
    }
  }
}
