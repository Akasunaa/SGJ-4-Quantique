using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _cameraVelocity = 1f;
    [SerializeField] LineRenderer _lineRenderer;

    private LevelManager _levelManager;
    private GameObject _companion;
    private PlayerIntrication _playerIntrication;
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
        _playerIntrication = GetComponent<PlayerIntrication>();
        _companion = _playerIntrication.Companion;

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
            if (_playerIntrication.IsDead)
            {
                DeplacementDead(new Vector2Int(h_input, v_input));
            }
            else
            {
                Deplacement(new Vector2Int(h_input, v_input));
            }
            
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
        if (Input.GetKey(KeyCode.Z))
        {
            v_input = 1;
            h_input = 0;
        }

        if (Input.GetKey(KeyCode.S))
        {
            v_input = -1;
            h_input = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            h_input = 1;
            v_input = 0;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            h_input = -1;
            v_input = 0;
        }
    }

    private void DeplacementDead(Vector2Int input)
    {
        Vector3Int cellPosition = _mapGrid.WorldToCell(transform.position);
        float distanceFromCompanion = (transform.position - _companion.transform.position).magnitude;
        float newDistanceFromCompanion = (transform.position + input.x * Vector3.right + input.y * Vector3.up - _companion.transform.position).magnitude;

        if (newDistanceFromCompanion <= distanceFromCompanion)
        {
            transform.Translate(input.x, input.y, 0);
            StopAllCoroutines();
            StartCoroutine(MoveCamera());
            if (newDistanceFromCompanion <= 0.001)
                _playerIntrication.Revive();
        }

    }

    void Deplacement(Vector2Int input)
    {
        Vector3Int cellPosition = _mapGrid.WorldToCell(transform.position);
        Tile tile = (Tile) _tilemap.GetTile(new Vector3Int(cellPosition.x + input.x, cellPosition.y + input.y, cellPosition.z));
        if (input != Vector2Int.zero)
        {
            if (tile == _tiles[0])
            {
                transform.Translate(input.x, input.y, 0);
                StopAllCoroutines();
                StartCoroutine(MoveCamera());
            }
            else if (tile == _tiles[2])
            {
                transform.Translate(input.x, input.y, 0);
                StopAllCoroutines();
                StartCoroutine(MoveCamera());
                Deplacement(input);
            }
            else if (tile == _tiles[3])
            {
                Deplacement(-input);
            }
        }

            
            
        //rb.velocity = new Vector2(h_input, v_input).normalized * speed;

    }

    private IEnumerator MoveCamera()
    {
        Vector3 directionTemp = (transform.position - _camera.transform.position);
        Vector3 direction = (new Vector3(directionTemp.x, directionTemp.y, 0f));
        Vector3 directionNormalized = direction.normalized;
        float distance = direction.magnitude;
        float oldDistance = distance;

        while (distance >= 0.0001 && oldDistance >= distance)
        {
            _camera.transform.Translate(directionNormalized * _cameraVelocity * Time.deltaTime);
            oldDistance = distance;
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
