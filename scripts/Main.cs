using Godot;
using System;

public class Main : Node {
  private Viewport root;
  private Dictionary<string, PackedScene> scenes = new Dictionary<string, PackedScene>();
  private string[] scene_names = { "Menu", "Game" };
  public static int player1Score = 0;
  public static int player2Score = 0;

  public override void _Ready() {
    root = GetTree().GetRoot();
    loadScenes();
    root.AddChild(scenes["Menu"].Instance());
  }

  private void loadScenes() {
    foreach (string scene_name in scene_names) {
      PackedScene scene = (PackedScene) GD.Load("res://scenes/" + scene_name + ".tscn");
      scenes.Add(scene_name, scene);
    }
  }

  private void changeScene(string scene_name) {
    root.RemoveChild(root.GetChild(0));
    root.AddChild(scenes[scene_name].Instance());
  }

  private void _on_Menu_start_game() {
    changeScene("Game");
  }
}
