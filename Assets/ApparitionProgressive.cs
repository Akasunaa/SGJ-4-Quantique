using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ApparitionProgressive : MonoBehaviour
{
    private GameObject solMur;
    private GameObject plusMoins;

    private void Awake()
    {
        solMur = transform.Find("Sol_Mur").gameObject;
        plusMoins = transform.Find("Plus_Moins").gameObject;

        solMur.SetActive(false);
        plusMoins.SetActive(false);
        Zone.NewZone += ZoneChange;
    }

    public void ZoneChange(int value)
    {
        if (value == 2)
            solMur.SetActive(true);
        if (value == 3)
            plusMoins.SetActive(true);

    }
}
