extends Camera2D

@export var _target_to_follow : Node2D

func _physics_process(delta):
	global_position = Vector2(_target_to_follow.global_position.x, minf(_target_to_follow.global_position.y,140))
