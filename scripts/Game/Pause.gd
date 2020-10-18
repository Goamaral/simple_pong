extends CanvasLayer

# Private - Onready #
onready var menu_node: Control = $"./Menu"
onready var world_node = $"/root/Scene/World"

# Signal Handling #
func _input(event):
	if event.is_action_pressed("ui_cancel"):
		if (is_paused()):
			resume()
		else:
			pause()
	elif event.is_action_pressed("ui_accept"):
		resume()

func _on_ContinueButton_pressed():
	resume()

func _on_MainMenuButton_pressed():
	SceneChanger.change_scene("MainMenu")

# General #
func pause():
	if (!is_paused()):
		world_node.pause()
		menu_node.visible = true
	
func resume():
	if (is_paused()):
		world_node.resume()
		menu_node.visible = false
	
func is_paused():
	return menu_node.visible