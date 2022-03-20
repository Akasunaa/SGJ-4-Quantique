using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTata : MonoBehaviour
{
    
    [SerializeField] int nbOfCase;
    [SerializeField] Orientation orientation;
    [SerializeField] BoxCollider2D _boxCollider2D;
    int count = 0;
    [SerializeField]int tempo = 1;
    float time;
    int switchOrientation = 1;
    private Collider2D _playerCollider;
    private PlayerIntrication _playerIntrication;
    private bool _justMoved = false;

    public enum Orientation
    {
        Horizontale,
        Verticale
    }

    private void Awake()
    {
        if (_boxCollider2D == null)
        {
            Debug.LogWarning($"No boxCollider affected to {name} had to get at runtime");
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }
            
    }

    private void OnEnable()
    {
        //Tellement sale :'(
        _playerCollider = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Collider2D>();
        _playerIntrication = FindObjectOfType<PlayerIntrication>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_justMoved)
        {
            _justMoved = false;
            if (_boxCollider2D.IsTouching(_playerCollider))
                _playerIntrication.LoseIntrication();
        }
        time = time + Time.fixedDeltaTime;
        if (time >= tempo)
        {

            Deplacement();
            time = time % tempo;
        }
    }

    void Deplacement()
    {
        count += 1;
        if (count >= nbOfCase)
        {
            switchOrientation *= -1;
            count = 0;
        }
        if (orientation == Orientation.Horizontale)
        {
            transform.Translate(switchOrientation, 0, 1);
        }
        else 
        {
            transform.Translate(0, switchOrientation, 1);
        }
        _justMoved = true;
    }



}
