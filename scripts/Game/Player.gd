# Game/Player.gd
extends KinematicBody2D

# Export
export var player: String = "_player"
export var force: int = 400

# Private
onready var default_position: Vector2 = position

# Signal Handling
func _process(delta: float):
	var is_up: bool = Input.is_action_pressed(player + "_up")
	var is_down: bool = Input.is_action_pressed(player + "_down")
	var applied_force: int = 0

	if is_up:
		applied_force = -force
	elif is_down:
		applied_force = force
		
	#warning-ignore:return_value_discarded
	move_and_collide(Vector2(0, applied_force) * delta)
	
# General
func reset():
	position = default_position