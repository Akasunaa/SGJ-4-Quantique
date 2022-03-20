using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntrication : MonoBehaviour
{
    [SerializeField] GameObject _playerSeul;
    [SerializeField] GameObject _companion;
    [SerializeField] GameObject _player;

    private LevelManager _levelManager;
    private Grid _gridMap;
    private int _intrication = 90;
    private Vector3 offset = new Vector3(0.5f, 0.5f, 0f);
    // Start is called before the first frame update

    public bool IsDead { get; set; } = false;
    public GameObject Companion { get { return (_companion); } }

    private void OnEnable()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _gridMap = _levelManager.MapGrid;
    }

    public void LoseIntrication()
    {
        _intrication -= 30;
        if (_intrication <= 0)
        {
            _intrication = 0;
            Die();
        }    
    }

    private void Die()
    {
        IsDead = true;
        _player.SetActive(false);
        _playerSeul.SetActive(true);
        _companion.SetActive(true);
        Vector3Int cell;
        if (transform.position.magnitude > 5)
            cell = _gridMap.WorldToCell(transform.position - transform.position.normalized * 5);
        else
            cell = Vector3Int.zero;
        _companion.transform.position = cell + offset;
    }

    public void Revive()
    {
        IsDead = false;
        _player.SetActive(true);
        _playerSeul.SetActive(false);
        _companion.SetActive(false);
        _intrication = 90;
    }
}
