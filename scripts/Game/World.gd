extends Control

# Signals #
signal resume()
signal pause()

# Private - General #
var paused: bool = true

# Signal Handling #
func _ready():
	#warning-ignore:return_value_discarded
	SceneChanger.connect("scene_changed", self, "resume")

# General #
func pause():
	if (!paused):
		paused = true
		emit_signal("pause")
	
func resume():
	if (paused):
		paused = false
		emit_signal("resume")