# Game/Scene.gd
extends Node

# Export
export var total_rounds: int
export var winner_hold_time: float = 3

# Local
var played_rounds: int = 0
var scoreboard: Dictionary = { "left_player": 0, "right_player": 0 } 
var current_node: Control = null
enum { CONTINUE, END }

# Scene main nodes
onready var world_node: Control = $World
onready var scoreboard_node: Control = $Scoreboard
onready var winner_node: Control = $Winner

# Helper nodes
onready var scoreboard_node_value = $Scoreboard/Value
onready var winner_node_value = $Winner/Value
onready var world_node_ball = $World/Ball
onready var world_node_left_player = $World/Players/LeftPlayer
onready var world_node_right_player = $World/Players/RightPlayer

# Signal Handling
func _ready():
	hide_all_main_nodes()
	update_current_node(world_node)

#warning-ignore:unused_argument
func _on_goal(body: KinematicBody2D, player: String):
	scoreboard[player] += 1
	played_rounds += 1
	if next_game_state() == CONTINUE:
		show_scoreboard()
	else:
		show_winner()

func _on_NextRound_pressed():
	world_node_ball.reset()
	world_node_left_player.reset()
	world_node_right_player.reset()
	update_current_node(world_node)
	
func _input(event):
	if event.is_action_pressed("ui_accept") and current_node == scoreboard_node:
		_on_NextRound_pressed()

# Displayers
func hide_all_main_nodes() -> void:
	world_node.hide()
	scoreboard_node.hide()
	winner_node.hide()

func update_current_node(new_node: Control):
	if current_node != null: current_node.hide()
	current_node = new_node
	current_node.show()

func show_scoreboard() -> void:
	scoreboard_node_value.set_text("%d - %d" % [scoreboard["left_player"], scoreboard["right_player"]])
	update_current_node(scoreboard_node)

func show_winner() -> void:
	if scoreboard["left_player"] > scoreboard["right_player"]:
		# Left player won
		winner_node_value.set_text("Left Player Won")
	else:
		# Right player won
		winner_node_value.set_text("Right Player Won")

	update_current_node(winner_node)
	yield(get_tree().create_timer(winner_hold_time), "timeout")
	SceneChanger.change_scene("MainMenu")

# General
func next_game_state() -> int:
	if played_rounds >= total_rounds and scoreboard["left_player"] != scoreboard["right_player"]:
		return END
	else:
		return CONTINUE