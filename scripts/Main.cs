using Godot;
using System;

public class Main : Node {
  private Dictionary<string, PackedScene> scenes = new Dictionary<string, PackedScene>();
  private string[] scene_names = { "Menu", "Game" };
  public static int player1Score = 0;
  public static int player2Score = 0;

  public override void _Ready() {
    loadScenes();
    this.AddChild(scenes["Menu"].Instance());
  }

  private void loadScenes() {
    foreach (string scene_name in scene_names) {
      PackedScene scene = (PackedScene) Godot.GD.Load("res://scenes/" + scene_name + ".tscn");
      scenes.Add(scene_name, scene);
    }
  }

  private void changeScene(string scene_name) {
    Godot.GD.Print("Changing to scene " + scene_name);
    this.RemoveChild(this.GetChild(0));
    this.AddChild(scenes[scene_name].Instance());
    Godot.GD.Print("Changed");
  }

  public void startGame() {
    changeScene("Game");
  }
}
