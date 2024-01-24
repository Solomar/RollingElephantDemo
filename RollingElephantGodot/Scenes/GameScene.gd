extends Node2D



func _move_right_frame_left(body):
	if body is RollingElephant:
		$RightFrame.position = $LeftFrame.position - \
			Vector2($LeftFrame._total_length/2 + $RightFrame._total_length/2,0)

func _move_right_frame_right(body):
	if body is RollingElephant:
		$RightFrame.position = $LeftFrame.position + \
			Vector2($LeftFrame._total_length/2 + $RightFrame._total_length/2,0)

func _move_left_frame_left(body):
	if body is RollingElephant:
		$LeftFrame.position = $RightFrame.position - \
			Vector2($LeftFrame._total_length/2 + $RightFrame._total_length/2,0)

func _move_left_frame_right(body):
	if body is RollingElephant:
		$LeftFrame.position = $RightFrame.position + \
			Vector2($LeftFrame._total_length/2 + $RightFrame._total_length/2,0)
