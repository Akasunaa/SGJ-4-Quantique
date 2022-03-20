using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehavior : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int tempo = 1;

    private float time;
    private Collider2D _playerCollider;
    private PlayerIntrication _playerIntrication;
    private bool _justMoved = false;
    private BoxCollider2D[] _colliders;
    private Enemy _enemy;

    private void Awake()
    {
        Zone.NewZone += ChangeTempo;
        _colliders = GetComponents<BoxCollider2D>();
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        //Tellement sale :'(
        _playerCollider = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Collider2D>();
        _playerIntrication = FindObjectOfType<PlayerIntrication>();
    }

    private void OnDestroy()
    {
        Zone.NewZone -= ChangeTempo;
    }
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        time = time + Time.fixedDeltaTime;
        if (_justMoved)
        {
            _justMoved = false;
            foreach (BoxCollider2D collider in _colliders)
            {
                if (collider.IsTouching(_playerCollider))
                    _playerIntrication.LoseIntrication();
            }

        }
        if (time >= tempo)
        {
            _justMoved = true;
            _enemy.Deplacement();
            time = time % tempo;
        }
    }



    void ChangeTempo(int nbZone)
    {
        //rahoui je vais coder ça
    }

}
