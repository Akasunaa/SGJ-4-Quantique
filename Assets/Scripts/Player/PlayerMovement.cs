using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _cameraVelocity = 1f;
    [SerializeField] LineRenderer _lineRenderer;

    private LevelManager _levelManager;
    private Tile[] _tiles;
    private Tilemap _tilemap;
    private Grid _mapGrid;
    private Camera _camera;
    private Rigidbody2D rb;
    private float speed = 10;
    private int h_input;
    private int v_input;
    private bool canMove;
    private float time;
    private float tempo = 1f;

    private void OnEnable()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _tiles = _levelManager.Tiles;
        _tilemap = _levelManager.Tilemap;
        _mapGrid = _levelManager.MapGrid;
        _camera = Camera.main;
    }

    private void Awake()
    {
        Zone.NewZone += ChangeTempo;
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //StartCoroutine(FreezePlayer(time));
        
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.positionCount = 0;
        time = time + Time.deltaTime;
        GetInput();
        if (time >= tempo)
        {
            
            Deplacement();
            time = time % tempo;
            h_input = 0;
            v_input = 0;
        }
        else if (h_input != 0 || v_input != 0)
        {
            Vector3 possibleTranslation = new Vector3(h_input, v_input, 0f);

            _lineRenderer.positionCount = 4;
            _lineRenderer.SetPosition(0, transform.position + possibleTranslation + Vector3.left * 0.5f + Vector3.up * 0.5f);
            _lineRenderer.SetPosition(1, transform.position + possibleTranslation + Vector3.right * 0.5f + Vector3.up * 0.5f);
            _lineRenderer.SetPosition(2, transform.position + possibleTranslation + Vector3.right * 0.5f + Vector3.down * 0.5f);
            _lineRenderer.SetPosition(3, transform.position + possibleTranslation + Vector3.left * 0.5f + Vector3.down * 0.5f);
        }
       
        //GetInput();
        //Deplacement();


    }

    void Intrication()
    {
        //mettre des paliers pour changer les sprites
    }
    void GetInput()
    {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
        {
            v_input = 1;
            h_input = 0;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            v_input = -1;
            h_input = 0;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            h_input = 1;
            v_input = 0;
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            h_input = -1;
            v_input = 0;
        }
    }
    void Deplacement()
    {
        Vector3Int cellPosition = _mapGrid.WorldToCell(transform.position);
        Tile tile = (Tile) _tilemap.GetTile(new Vector3Int(cellPosition.x + h_input, cellPosition.y + v_input, cellPosition.z));
        if (tile != _tiles[1] && (h_input != 0 || v_input != 0))
        {
            transform.Translate(h_input, v_input, 0);
            StartCoroutine(MoveCamera());
        }
            
            
        //rb.velocity = new Vector2(h_input, v_input).normalized * speed;

    }

    private IEnumerator MoveCamera()
    {
        Vector3 directionTemp = (transform.position - _camera.transform.position);
        Vector3 direction = new Vector3(directionTemp.x, directionTemp.y, 0f);
        float distance = direction.magnitude;

        Debug.Log("Hey " + distance);
        while (distance >= 0.0001)
        {
            _camera.transform.Translate(direction * _cameraVelocity * Time.deltaTime);
            distance = distance - _cameraVelocity * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
      
    }

    private void ChangeTempo(int nbZone)
    {
        tempo = nbZone;
    }

    private void OnDestroy()
    {
        Zone.NewZone -= ChangeTempo;
    }
}
