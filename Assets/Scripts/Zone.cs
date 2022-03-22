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
    public static event Action CardGainEnergie;
    public static event Action CardWin;
    public static event Action CardBase;

    private bool firstTimeQuitlvl1 = false;
    private bool firstTimeQuitlvl3 = false;
    private bool firstTimeQuitlvl2 = false;
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
        if (nbZone == 1)
        {
            if (firstTimeQuitlvl1 == false)
            {
                firstTimeQuitlvl1 = true;
                CardGainEnergie?.Invoke();
            }
        }
        else if (nbZone == 2)
        {
            if (firstTimeQuitlvl2 == false)
            {
                firstTimeQuitlvl2 = true;
                CardBase?.Invoke();
            }
        }
        else if (nbZone == 3)
        {
            if (firstTimeQuitlvl3 == false)
            {
                firstTimeQuitlvl3 = true;
                CardWin?.Invoke();
            }
        }
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
