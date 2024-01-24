@tool
extends EditorScript
func _run():
	var _children = get_scene().get_children()
	for child in _children:
		_try_to_tile(child)

func _try_to_tile(node):
	if node is TileCollection:
		node.update_tiles()
	elif node.get_child_count() > 0:
		var _children = node.get_children()
		for child in _children:
			_try_to_tile(child)
