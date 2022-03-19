using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField]int nbZone=1;
    private LevelManager _levelManager;

    public static event Action<int> NewZone;
    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        NewZone?.Invoke(nbZone+1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewZone?.Invoke(nbZone);
    }
}
