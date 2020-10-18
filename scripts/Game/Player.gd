# Game/Player.gd #
extends KinematicBody2D

# Public #
export var player: String = "_player"
export var force: int = 400

# Private - Onready #
onready var default_position: Vector2 = position
onready var world_node = $"/root/Scene/World"

# Private - General #
var paused: bool = true

# Signal Handling #
func _ready():
	#warning-ignore:return_value_discarded
	world_node.connect("pause", self, "_pause")
	#warning-ignore:return_value_discarded
	world_node.connect("resume", self, "_resume")
	
func _resume():
	paused = false
	
func _pause():
	paused = true

func _process(delta: float):
	if (paused):
		return false
		
	var is_up: bool = Input.is_action_pressed(player + "_up")
	var is_down: bool = Input.is_action_pressed(player + "_down")
	var applied_force: int = 0

	if is_up:
		applied_force = -force
	elif is_down:
		applied_force = force
		
	#warning-ignore:return_value_discarded
	move_and_collide(Vector2(0, applied_force) * delta)
	
# General #
func reset():
	position = default_position