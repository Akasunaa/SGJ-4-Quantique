using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] GameObject[] cartes;

    private void OnEnable()
    {
        foreach (GameObject carte in cartes)
        {
            carte.SetActive(false);
        }
    }

    public void CloseAll()
    {
        foreach (GameObject carte in cartes)
        {
            carte.SetActive(false);
        }
    }
}
