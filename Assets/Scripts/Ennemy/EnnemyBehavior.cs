using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehavior : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float tempo = 1;

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
            _enemy.Rotation();
            time = time % tempo;
        }
    }



    void ChangeTempo(int nbZone)
    {
        if (nbZone == 1)
        {
            tempo = 1;
        }
        else if (nbZone == 2)
        {
            tempo = 0.50f;
        }
        else if (nbZone == 3)
        {
            tempo = 0.33f;
        }
        else if (nbZone == 4)
        {
            tempo = 0.1f;
        }
        else if (nbZone == 5)
        {
            tempo = 3600f;
        }
    }

}
