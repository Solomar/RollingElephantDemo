extends Node2D

@export var tile_size_reference : float
@export var _floor_tile_collection: TileCollection
var _total_length : float

func _ready():
	_total_length = _floor_tile_collection._tile_count * tile_size_reference
	$LeftSide/CollisionShape2D.shape.set_size(Vector2(_total_length/2-tile_size_reference*2, 800))
	$LeftSide.position = Vector2(-_total_length/4,0)
	$RightSide/CollisionShape2D.shape.set_size(Vector2(_total_length/2-tile_size_reference*2, 800))
	$RightSide.position = Vector2(_total_length/4,0)
