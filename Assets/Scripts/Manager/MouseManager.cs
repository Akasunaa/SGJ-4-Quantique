using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Tilemap _tilemap;
    [SerializeField] Grid _mapGrid;
    // Tiles 0 to 3 are for the first zone
    // Tiles 4 to 7 are for the second zone
    // Tiles 8 to 11 are for the third
    [SerializeField] Tile[] _tiles;
    [SerializeField] Sprite[] _tilesSprite;
    private bool _isGroundWallBasis = true;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);

    }

    public void GetInput()
    {
        Vector3Int positionOnGrid;

        positionOnGrid = _mapGrid.WorldToCell(transform.position);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(_isGroundWallBasis);
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    Vector3Int cellToMeasure = new Vector3Int(positionOnGrid.x + i, positionOnGrid.y + j, positionOnGrid.z);
                    Tile measuredTile = (Tile)_tilemap.GetTile(cellToMeasure);
                    if (!_isGroundWallBasis && (measuredTile == _tiles[0] || measuredTile == _tiles[1]))
                    {
                        if (Random.Range(0, 2) == 0)
                            _tilemap.SetTile(cellToMeasure, _tiles[2]);
                        else
                            _tilemap.SetTile(cellToMeasure, _tiles[3]);
                    }
                    else if (_isGroundWallBasis && (measuredTile == _tiles[2] || measuredTile == _tiles[3]))
                    {
                        if (Random.Range(0, 2) == 0)
                            _tilemap.SetTile(cellToMeasure, _tiles[0]);
                        else
                            _tilemap.SetTile(cellToMeasure, _tiles[1]);
                    }
                }
            }
            
            //_tilemap.SetTile(_mapGrid.WorldToCell(transform.position), _tile);
        }
    }

    public void ChangeBasis(bool isGroundWall)
    {
        _isGroundWallBasis = isGroundWall;
    }
}
