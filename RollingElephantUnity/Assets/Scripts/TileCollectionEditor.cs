using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TileCollection))]
public class TileCollectionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TileCollection script = (TileCollection)target;
        if (GUILayout.Button("Update Tiles"))
        {
            script.UpdateTiles();
        }
    }
}
