using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFrame : MonoBehaviour
{
    [SerializeField]
    private TileCollection _baseTileCollection;
    private List<TileCollection> _allTileCollection;
    [SerializeField]
    private List<GameObject> _allBackgroundDecoration;
    public int BaseTileCount
    {
        get { return _baseTileCollection.TileCount; }
    }

    void Start()
    {
        _allTileCollection = GetComponentsInChildren<TileCollection>().ToList();

        // Uses the tile count to determine the distance of the side frames
        //var tileCount = _baseTileCollection.TileCount;
        //_leftSideFrame.transform.position = new Vector3(-tileCount, 0, 0);
        //_rightSideFrame.transform.position = new Vector3(tileCount, 0, 0);

        //foreach(var tileCollection in _allTileCollection)
        //{
        //    var leftTiles   = Instantiate(tileCollection.gameObject, _leftSideFrame.transform);
        //    var rightTiles  = Instantiate(tileCollection.gameObject, _rightSideFrame.transform);
        //    tileCollection.AssociateLeftRightTiles(leftTiles.GetComponent<TileCollection>(), rightTiles.GetComponent<TileCollection>());
        //}

        //foreach(var decoration in _allBackgroundDecoration)
        //{
        //    var localPosition = decoration.transform.localPosition;
        //    var decorationCopy = Instantiate(decoration, _leftSideFrame.transform);
        //    decorationCopy.transform.localPosition = localPosition;

        //    decorationCopy = Instantiate(decoration, _rightSideFrame.transform);
        //    decorationCopy.transform.localPosition = localPosition;
        //}
    }
}
