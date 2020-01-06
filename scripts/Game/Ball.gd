# Game/Ball.gd
extends KinematicBody2D

# Export
export var force: int = 10
export var default_vector = Vector2(300, 0)

# Private
var vector: Vector2 = default_vector
onready var default_position: Vector2 = position

# World player nodes
onready var left_player_node = $"../Players/LeftPlayer"
onready var right_player_node = $"../Players/RightPlayer"

# Signal Handling
func _ready():
	if Utils.randi_range(0, 2) % 2 == 1:
		vector.x *= -1

func _process(delta: float):
	var collision: KinematicCollision2D = move_and_collide(vector * delta)
	
	if (collision != null):
		vector = vector.bounce(collision.normal)

		var partial_x: float = abs(vector.x) / 10
		vector.y += randf() * (2 * partial_x) - partial_x

		if collision.collider == left_player_node:
			vector.x += force

		if collision.collider == right_player_node:
			vector.x -= force
			
# General
func reset():
	position = default_position
	vector = default_vector