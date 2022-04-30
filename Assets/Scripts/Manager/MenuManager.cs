using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private PlayerIntrication _intrication;
    private bool _alreadyMetEnemy;
    private Enemy _enemy;

    // Start is called before the first frame update
    private void OnEnable()
    {
        _intrication = FindObjectOfType<PlayerIntrication>();
        _enemy = GetComponentInChildren<Enemy>();
        _enemy.gameObject.SetActive(false);
    }
    private void Start()
    {
        _intrication.Die();
    }

    private void Update()
    {
        if (_alreadyMetEnemy && !_intrication.IsDead)
        {
            SceneManager.LoadScene("SceneFinale");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alreadyMetEnemy = true;
        _enemy.gameObject.SetActive(true);
        _enemy.transform.position = _intrication.transform.position;
        _intrication.Die();
    }
}
