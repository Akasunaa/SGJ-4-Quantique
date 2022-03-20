using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{

    [SerializeField] GameObject[] cartes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Echap()
    {
        for(int i = 0; i < cartes.Length; i++)
        {
            cartes[i].SetActive(false);
        }
    }

    public void Carte1()
    {
        cartes[0].SetActive(true);
    }
    public void Carte2()
    {
        cartes[1].SetActive(true);
    }
    public void Carte3()
    {
        cartes[2].SetActive(true);
    }
    public void Carte4()
    {
        cartes[3].SetActive(true);
    }
    public void Carte5()
    {
        cartes[4].SetActive(true);
    }
    public void Carte6()
    {
        cartes[5].SetActive(true);
    }
}

