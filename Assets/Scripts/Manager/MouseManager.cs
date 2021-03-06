using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour
{
    [SerializeField] GraphicRaycaster _graphicRaycaster;
    [SerializeField] EventSystem _eventSystem;

    private PointerEventData _pointerEventData;
    private Grid _mapGrid;
    /* Tiles 0 to 3 are for the first zone
     Tiles 4 to 7 are for the second zone
     Tiles 8 to 11 are for the third */
    private Tile[] _tiles;
    private Tilemap _tilemap;
    private bool _isGroundWallBasis = true;
    private LevelManager _levelManager;
    private bool _shouldClick = false;
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _tiles = _levelManager.Tiles;
        _tilemap = _levelManager.Tilemap;
        _mapGrid = _levelManager.MapGrid;
        Zone.NewZone += ZoneChange;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_shouldClick)
        {
            GetInput();
        }
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);


    }

    public void GetInput()
    {
        Vector3Int positionOnGrid;

        positionOnGrid = _mapGrid.WorldToCell(transform.position);
        _lineRenderer.positionCount = 4;
        _lineRenderer.SetPosition(0, positionOnGrid  + Vector3.up * 1f);
        _lineRenderer.SetPosition(1, positionOnGrid + Vector3.right * 1f + Vector3.up * 1);
        _lineRenderer.SetPosition(2, positionOnGrid + Vector3.right * 1f);
        _lineRenderer.SetPosition(3, positionOnGrid);
        if (Input.GetMouseButtonDown(0))
        {
            List<RaycastResult> results = new List<RaycastResult>();

            _pointerEventData = new PointerEventData(_eventSystem);
            _pointerEventData.position = Input.mousePosition;
            _graphicRaycaster.Raycast(_pointerEventData, results);
            if (results.Count == 0)
            {
                Vector3Int cellToMeasure = new Vector3Int(positionOnGrid.x, positionOnGrid.y, positionOnGrid.z);
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
                else if (!_isGroundWallBasis && (measuredTile == _tiles[4] || measuredTile == _tiles[5]))
                {
                    if (Random.Range(0, 2) == 0)
                        _tilemap.SetTile(cellToMeasure, _tiles[6]);
                    else
                        _tilemap.SetTile(cellToMeasure, _tiles[7]);
                }
                else if (_isGroundWallBasis && (measuredTile == _tiles[6] || measuredTile == _tiles[7]))
                {
                    if (Random.Range(0, 2) == 0)
                        _tilemap.SetTile(cellToMeasure, _tiles[4]);
                    else
                        _tilemap.SetTile(cellToMeasure, _tiles[5]);
                }
                else if (!_isGroundWallBasis && (measuredTile == _tiles[8] || measuredTile == _tiles[9]))
                {
                    if (Random.Range(0, 2) == 0)
                        _tilemap.SetTile(cellToMeasure, _tiles[10]);
                    else
                        _tilemap.SetTile(cellToMeasure, _tiles[11]);
                }
                else if (_isGroundWallBasis && (measuredTile == _tiles[10] || measuredTile == _tiles[11]))
                {
                    if (Random.Range(0, 2) == 0)
                        _tilemap.SetTile(cellToMeasure, _tiles[8]);
                    else
                        _tilemap.SetTile(cellToMeasure, _tiles[9]);
                }


            }

        }
    }

    public void ZoneChange(int value)
    {
        if (value == 2)
            _shouldClick = true;
    }

    public void ChangeBasis(bool isGroundWall)
    {
        _isGroundWallBasis = isGroundWall;
    }
}
