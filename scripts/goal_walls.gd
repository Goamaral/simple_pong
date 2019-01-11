extends Area2D

var player_1_score = 0
var player_2_score = 0

func _on_Left_body_entered(body):
  player_2_score += 1
  print_scoreboard()

func _on_Right_body_entered(body):
  player_1_score += 1
  print_scoreboard()

func print_scoreboard():
  print(str(player_1_score) + " - " + str(player_2_score))