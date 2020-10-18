extends Node

func _on_play():
	SceneChanger.change_scene("Game")
	
func _input(event):
	if event.is_action_pressed("ui_accept"):
		SceneChanger.change_scene("Game")