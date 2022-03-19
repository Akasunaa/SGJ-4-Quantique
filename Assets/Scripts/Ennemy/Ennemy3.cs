using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy3 : MonoBehaviour
{
    float time;
    int tempo = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time = time + Time.deltaTime;
        if (time >= tempo)
        {

            Deplacement();
            time = time % tempo;
        }
    }

    void Deplacement()
    {
        int orientation = Random.Range(0, 1);
        if (orientation == 0)
        {
            int sens = Random.Range(-1, 1);
            transform.Translate(0, sens, 1);
        }
        else
        {
            int sens = Random.Range(-1, 1);
            transform.Translate(sens, 0, 1);
        }

    }
}
