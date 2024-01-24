using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Sprite dirtyTile;
    public Sprite cleanTile;

    private bool _cleaned;
    private Tile _leftDuplicateTile;
    private Tile _rightDuplicateTile;
    private SpriteRenderer _spriteRenderer;

    // Get Setters
    public Tile SetLeftTile
    {
        set { _leftDuplicateTile = value; }
    }
    public Tile SetRightTile
    {
        set { _rightDuplicateTile = value; }
    } 

    /// <summary>
    /// Tile functions
    /// </summary>
    private void Start()
    {
        _cleaned = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(!_cleaned && collider.CompareTag("RollingElephant"))
        {
            CleanTile();
        }
    }

    public void CleanTile()
    {
        _cleaned = true;
        _spriteRenderer.sprite = cleanTile;
        if (_leftDuplicateTile != null)
            _leftDuplicateTile.CleanTile();
        if (_rightDuplicateTile != null)
            _rightDuplicateTile.CleanTile();
    }
}
