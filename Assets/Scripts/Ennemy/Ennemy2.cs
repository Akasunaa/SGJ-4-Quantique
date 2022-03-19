using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy2 : MonoBehaviour
{
    float time;
    float tempo=1;
    float rotation;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 1) == 0)
        {
            rotation = 45f;
        }
        else
        {
            rotation = -45f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time >= tempo)
        {

            Deplacement();
            Rotation();
            time = time % tempo;
        }
    }

    void Deplacement()
    {
        int orientation = Random.Range(0,1);
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

    void Rotation()
    {
        transform.rotation *= Quaternion.Euler(0, 0, rotation);
    }


}
