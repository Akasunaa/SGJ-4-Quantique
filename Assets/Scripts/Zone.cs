using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField]int nbZone=1;
    private LevelManager _levelManager;

    public static event Action<int> NewZone;
    public static event Action<int> WinningZone;
    void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        if (nbZone == 1)
        {
            NewZone?.Invoke(nbZone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        NewZone?.Invoke(nbZone+1);
        WinningZone?.Invoke(nbZone + 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //NewZone?.Invoke(nbZone);
    }

    private void OnStayEnter2D(Collider2D collision)
    {
        if (nbZone == 1)
        {
            NewZone?.Invoke(nbZone);
        }
        
    }
}
