using Godot;
using System;

public class Ball : KinematicBody2D {
  private int force = 10;
  private Vector2 v = new Vector2(300, 0);

  public override void _Ready() {
    if (new Random().Next(0, 2) % 2 == 1) {
      v.x *= -1;
    }
  }

  public override void _PhysicsProcess(float delta) {
    KinematicCollision2D collision = MoveAndCollide(v * delta);

    if (collision != null) {
      v = v.Bounce(collision.Normal);

      float partial_x = Math.Abs(v.x) / 10;
      v.y += (float) new Random().NextDouble() * (2 * partial_x) - partial_x;

      if (collision.Collider.Get("name").Equals("Player1")) v.x += force;
      if (collision.Collider.Get("name").Equals("Player2")) v.x -= force;
    }
  }

  public void OnVisibilityNotifier2DScreenExited() {
    QueueFree();
  }
}