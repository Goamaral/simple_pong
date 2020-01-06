# Utils.gd
extends Node

# Math
static func randi_range(from: int, to: int) -> int:
	var number_range: int = to - from
	return randi() % number_range + from

# Scene management
func change_scene(scene_name: String) -> void:
	assert(get_tree().change_scene("scenes/%s.tscn" % scene_name) == OK)