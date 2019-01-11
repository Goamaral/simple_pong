extends KinematicBody2D

export var player_id = 0

func _ready():
	pass

func _process(delta):
	if Input.is_action_pressed("player_%s_up" % player_id):
		move_and_collide(Vector2(0, -5))
	elif Input.is_action_pressed("player_%s_down" % player_id):
		move_and_collide(Vector2(0, 5))

