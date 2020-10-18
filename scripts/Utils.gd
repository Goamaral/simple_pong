# Utils.gd
extends Node

# Math #
static func randi_range(from: int, to: int) -> int:
	var number_range: int = to - from
	return randi() % number_range + from