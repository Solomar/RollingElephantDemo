@tool
extends Node2D
class_name Tile

var _cleaned : bool
var _left_duplicate_tile : Tile :
	set(value):
		_left_duplicate_tile = value
	get:
		return _left_duplicate_tile
var _right_duplicate_tile : Tile :
	set(value):
		_right_duplicate_tile = value
	get:
		return _right_duplicate_tile

func _ready():
	_cleaned = false

func clean_tile():
	_cleaned = true
	$TileSprite.set_animation("clean")
	if _left_duplicate_tile != null:
		_left_duplicate_tile.clean_tile()
	if _right_duplicate_tile != null:
		_right_duplicate_tile.clean_tile()

func _on_area_2d_body_entered(body):
	if not _cleaned and body is RollingElephant:
		clean_tile()
