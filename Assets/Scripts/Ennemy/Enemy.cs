using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Enemy : MonoBehaviour
{
    private LevelManager _levelManager;
    private Tile[] _tiles;
    private Tilemap _tilemap;
    private Grid _mapGrid;

    private void OnEnable()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _tiles = _levelManager.Tiles;
        _tilemap = _levelManager.Tilemap;
        _mapGrid = _levelManager.MapGrid;

    }

    public abstract void Deplacement();

    public void DeplacementWithTile(Vector2Int input, int numberOfRecursion = 0)
    {
        if (numberOfRecursion >= 6)
            return;
        Vector3Int cellPosition = _mapGrid.WorldToCell(transform.position);
        Tile tile = (Tile)_tilemap.GetTile(new Vector3Int(cellPosition.x + input.x, cellPosition.y + input.y, cellPosition.z));
        if (input != Vector2Int.zero)
        {
            if (tile == _tiles[0])
            {
                transform.Translate(input.x, input.y, 0);
            }
            else if (tile == _tiles[2])
            {
                transform.Translate(input.x, input.y, 0);
                DeplacementWithTile(input, numberOfRecursion + 1);
            }
            else if (tile == _tiles[3])
            {
                DeplacementWithTile(-input, numberOfRecursion + 1);
            }
            else if (tile == _tiles[4])
            {
                transform.Translate(input.x, input.y, 0);
            }
            else if (tile == _tiles[6])
            {
                transform.Translate(input.x, input.y, 0);
                DeplacementWithTile(input, numberOfRecursion + 1);
            }
            else if (tile == _tiles[7])
            {
                DeplacementWithTile(-input, numberOfRecursion + 1);
            }
            else if (tile == _tiles[8])
            {
                transform.Translate(input.x, input.y, 0);
            }
            else if (tile == _tiles[10])
            {
                transform.Translate(input.x, input.y, 0);
                DeplacementWithTile(input, numberOfRecursion + 1);
            }
            else if (tile == _tiles[11])
            {
                DeplacementWithTile(-input, numberOfRecursion + 1);
            }
            else if (tile == _tiles[12])
            {
                transform.Translate(input.x, input.y, 0);
            }
        }
    }
}
