extends Node2D

@export var parallax_factor : float
@export var _reference_point : Node2D

func _physics_process(delta):
	position = Vector2(_reference_point.position.x * parallax_factor, 0) 
	_adjust_to_pixel()
	
func _adjust_to_pixel():
	global_position = Vector2(floor(global_position.x + 0.5), floor(global_position.y + 0.5))
