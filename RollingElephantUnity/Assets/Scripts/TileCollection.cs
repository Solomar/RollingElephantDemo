using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TileCollection : MonoBehaviour
{
    public GameObject tile;

    // Used only by main frame tile collections
    // to propagate changes
    public TileCollection leftSideCopy;
    public TileCollection rightSideCopy;

    [SerializeField]
    private int _tileCount;
    private List<Tile> _allTiles = new List<Tile>();
    [SerializeField]
    private BoxCollider2D _boxCollider2D;

    public int TileCount
    {
        get { return _tileCount; }
        set { _tileCount = value; }
    }

    public List<Tile> AllTiles
    {
        get { return _allTiles; }
    }

    private void Awake()
    {
        _allTiles = GetComponentsInChildren<Tile>().ToList();
    }

    public void UpdateTiles()
    {

        foreach (Tile tile in _allTiles)
        {
            DestroyImmediate(tile.gameObject);
        }
        _allTiles.Clear();

        for (int i = 0; i < _tileCount; i++)
        {
            GameObject go = Instantiate(tile, transform);
            if ((i & 1) == 1)
                go.transform.localPosition = new Vector3(-(i+1)*.5f, 0, 0);
            else
                go.transform.localPosition = new Vector3(i*0.5f, 0, 0);
            _allTiles.Add(go.GetComponent<Tile>());
        }

        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.size = new Vector2(_tileCount, _boxCollider2D.size.y);
    }

    // Called to link duplicated tiles from left and right frame to the main frame tiles.
    public void AssociateLeftRightTiles(TileCollection leftCollection, TileCollection rightCollection)
    {
        for (int i = 0; i < _tileCount; i++)
        {
            _allTiles[i].SetLeftTile = leftCollection.AllTiles[i].GetComponent<Tile>();
            _allTiles[i].SetRightTile = rightCollection.AllTiles[i].GetComponent<Tile>();
        }
    }
}
