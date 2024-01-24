@tool
extends Node2D
class_name TileCollection

@export var tile_scene : PackedScene 
@export var left_side_copy : TileCollection
@export var right_side_copy : TileCollection
@export var _tile_count : int

@export var _tiles : Array

func _ready():
	update_tiles()
	
func update_tiles():
	## "Be extremely cautious when manipulating the scene tree, 
	## especially via Node.queue_free, 
	## as it can cause crashes if you free a node 
	## while the editor runs logic involving it."
	## https://docs.godotengine.org/en/stable/tutorials/plugins/running_code_in_the_editor.html
	if Engine.is_editor_hint():
		for child in get_children():
			if child is Tile:
				child.queue_free()
		_tiles.clear()
	else:
		for tile in _tiles:
			tile.queue_free()
		_tiles.clear()
	
	for index in _tile_count:
		var new_tile = tile_scene.instantiate()
		add_child(new_tile)
		new_tile.name = "Tile" + str(index)
		if ((index & 1) == 1):
			new_tile.position = Vector2(-(index+1)*16, 0)
		else:
			new_tile.position = Vector2(index*16, 0)
		_tiles.append(new_tile)
		
		## Using @tool let's this run in the editor
		## but add_child doesn't persist on editor scenes
		## to have them persist you need to use this
		if Engine.is_editor_hint():
			new_tile.owner = self
			
	## Both of these are valid if you make a node 
	## Accessible using Unique Name
	## $RigidBody2D/TileCollectionCollisionShape
	## %TileCollectionCollisionShape
	
	## In this case I know the shape I gave it is a 
	%TileCollectionCollisionShape.shape.set_size(Vector2(_tile_count*32,5))

## I forgot I didn't actually end up using this part in my original code haha.
#func link_associated_tiles():
	#var index = 0
	#for tile in _tiles:
		#tile._left_duplicate_tile = left_side_copy._tiles[index]
		#tile._right_duplciate_tile = right_side_copy._tiles[index]
		#index += 1
