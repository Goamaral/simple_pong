using Godot;
using System;

public class Global : Node {
  private string[] scene_names = { "Menu", "Game" };
  public enum SceneType { Menu, Game }

  public static PackedScene Scene(SceneType scene_type) {
    return (PackedScene)GD.Load("res://scenes/" + scene_type.ToString() + ".tscn");
  }

  public static String ScenePath(SceneType scene_type) {
    return "res://scenes/" + scene_type.ToString() + ".tscn";
  }

  public static int player1Score = 0;
  public static int player2Score = 0;

  http://docs.godotengine.org/en/3.0/getting_started/step_by_step/singletons_autoload.html#custom-scene-switcher

  public void ChangeScene(Node current_scene, SceneType scene_type) {
    CallDeferred(nameof(DeferredChangeScene), current_scene, ScenePath(scene_type));
  }

  public void DeferredChangeScene(Node current_scene, SceneType scene_type) {

  }
}
