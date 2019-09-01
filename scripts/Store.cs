using Godot;
using System;

public class Store : Node {
  // PUBLIC
  public enum SceneType { Menu, Game, Scoreboard, Winner }
  public enum Component { AudioPlayer, CurrentScene }

  // PRIVATE

  // PUBLIC STATIC
  public static int player1Score = 0;
  public static int player2Score = 0;
  public static int totalRounds = 5;

  // PRIVATE STATUC
  private static Store instance = null;

  // DATA METHODS
  public static string Score() {
    return player1Score + " - " + player2Score;
  }

  public static int Winner() {    
    if (player1Score + player2Score < totalRounds) return 0;
    if (player1Score > player2Score) return 1;
    if (player1Score < player2Score) return 2;
    if (player1Score < player2Score) return 3;
    return 0;
  }

  public static void ScoreReset() {
    player1Score = player2Score = 0;
  }

  // LIFECYCLE METHODS
  public override void _Ready() {
    Store.instance = this;
    StartPlayer();
  }

  public override void _Process(float delta) {
    // Godot.GD.Print(Godot.Engine.GetFramesPerSecond() + " FPS");
  }

  // ROUTING HANDLERS
  public static PackedScene Scene(SceneType scene_type) {
    return (PackedScene)GD.Load("res://scenes/" + scene_type.ToString() + ".tscn");
  }

  public static String ScenePath(SceneType scene_type) {
    return "res://scenes/" + scene_type.ToString() + ".tscn";
  }

  public static void GotoScene(SceneType scene_type) {
    int winner;

    if (scene_type == SceneType.Scoreboard && (winner = Winner()) != 0) {
      instance.CallDeferred(nameof(DeferredGotoScene), SceneType.Winner);
    } else {
      instance.CallDeferred(nameof(DeferredGotoScene), scene_type);
    }
  }

  public void DeferredGotoScene(SceneType scene_type) {
    Node current_scene = Get(Component.CurrentScene);
    current_scene.Free();
    PackedScene next_scene = Scene(scene_type);
    current_scene = next_scene.Instance();
    this.AddChild(current_scene);
  }

  public Node Get(Component component) {
    return this.GetChild((int) component);
  }

  // PLAYER
  public Godot.AudioStreamPlayer Player() {
    return (Godot.AudioStreamPlayer) Get(Component.AudioPlayer);
  }

  public static void StartPlayer() {
    instance.Player().Play();
  }

  public static void StopPlayer() {
    instance.Player().Stop();
  }
}
