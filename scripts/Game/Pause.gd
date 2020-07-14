extends CanvasLayer

onready var menu_node: Control = $"./Menu"

func _input(event):
	if event.is_action_pressed("ui_cancel"):
		get_tree().paused = true
		menu_node.visible = true

func _on_ContinueButton_pressed():
	get_tree().paused = false
	menu_node.visible = false