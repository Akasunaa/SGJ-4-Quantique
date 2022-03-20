using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntrication : MonoBehaviour
{
    [SerializeField] GameObject _playerSeul;
    [SerializeField] GameObject _companion;
    [SerializeField] GameObject _player;
    [SerializeField] LineRenderer _deathLink;
    [SerializeField] int _maxIntrication = 90;
    
    private Animator[] _animators;
    private LevelManager _levelManager;
    private Grid _gridMap;
    private int _intrication = 90;
    private Vector3 offset = new Vector3(0.5f, 0.5f, 0f);

    private bool firstTimeHit = false;
    private bool firstTimeDecorrele = false;
    public static event Action CardProba;
    public static event Action CardDecorrele;


    public LineRenderer DeathLink { get { return (_deathLink); } }
    public bool IsDead { get; set; } = false;
    public GameObject Companion { get { return (_companion); } }

    private void Awake()
    {
        _animators = GetComponentsInChildren<Animator>();
        _intrication = _maxIntrication;
    }

    private void OnEnable()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _gridMap = _levelManager.MapGrid;
    }

    public void LoseIntrication()
    {
        if (firstTimeHit == false)
        {
            firstTimeHit = true;
            CardProba?.Invoke();
        }
        _intrication -= 30;
        foreach (Animator animator in _animators)
        {
            if (animator.tag == "Perso")
            {
                float previousValue = animator.GetFloat("Blend");
                animator.SetFloat("Blend", previousValue + 0.5f / 3);
            }
            else
            {
                float previousValue = animator.GetFloat("Blend");
                animator.SetFloat("Blend", previousValue + 1f / 3);
            }
        }
        if (_intrication <= 0)
        {
            _intrication = 0;
            Die();
        }    
    }

    public void Die()
    {
        if (firstTimeDecorrele == false)
        {
            firstTimeDecorrele = true;
            CardDecorrele?.Invoke();

        }
        IsDead = true;
        _deathLink.positionCount = 2;

        _player.SetActive(false);
        _playerSeul.SetActive(true);
        _companion.SetActive(true);
        Vector3Int cell;
        if (transform.position.magnitude > 5)
            cell = _gridMap.WorldToCell(transform.position - transform.position.normalized * 5);
        else
            cell = Vector3Int.zero;
        _companion.transform.position = cell + offset;
        _deathLink.SetPosition(0, _playerSeul.transform.position);
        _deathLink.SetPosition(1, _companion.transform.position);
    }

    public void Revive()
    {
        _deathLink.positionCount = 0;
        IsDead = false;
        _player.SetActive(true);
        _playerSeul.SetActive(false);
        _companion.SetActive(false);
        _intrication = _maxIntrication;
    }
}
