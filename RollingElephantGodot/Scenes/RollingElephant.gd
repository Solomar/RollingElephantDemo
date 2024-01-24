extends RigidBody2D
class_name RollingElephant

enum DIRECTION {LEFT, RIGHT}

@export var target_speed : float
@export var acceleration : float

var _current_direction : DIRECTION
var _jumping : bool

func _ready():
	_current_direction = DIRECTION.RIGHT
	_jumping = false;

func _process(delta):
	if Input.is_action_just_released("Left"):
		_current_direction = DIRECTION.LEFT
	if Input.is_action_just_released("Right"):
		_current_direction = DIRECTION.RIGHT
	if Input.is_action_just_released("Up"):
		if not _jumping:
			$JumpCooldown.start()
			$JumpTime.start()
			_jumping = true
			gravity_scale = 0.0
			angular_damp = 0.0
			linear_velocity = Vector2(linear_velocity.x, -400.0)
			
func _physics_process(delta):
	var x_speed
	if _current_direction == DIRECTION.LEFT:
		x_speed = clampf(linear_velocity.x - acceleration * delta, -target_speed, target_speed)
	if _current_direction == DIRECTION.RIGHT:
		x_speed = clampf(linear_velocity.x + acceleration * delta, -target_speed, target_speed)
	linear_velocity = Vector2(x_speed, linear_velocity.y)
	_adjust_to_pixel()
	
func _on_jump_cooldown_timeout():
	_jumping = false

func _on_jump_time_timeout():
	gravity_scale = 1.0
	angular_damp = 1.0
	
func _adjust_to_pixel():
	global_position = Vector2(floor(global_position.x + 0.5), floor(global_position.y + 0.5))


func _on_timer_timeout():
	pass # Replace with function body.
