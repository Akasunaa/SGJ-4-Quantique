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
        Debug.Log("HEY");
        //for(int i = 0; i < cartes.Length; i++)
        //{
        //    cartes[i].SetActive(false);
        //}
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

    public void Carte7()
    {
        cartes[6].SetActive(true);
    }


    public void Carte8()
    {
        cartes[7].SetActive(true);
    }


    public void Carte9()
    {
        cartes[8].SetActive(true);
    }

    public void Carte10()
    {
        cartes[9].SetActive(true);
    }


}

