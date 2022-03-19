using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy1: MonoBehaviour
{
    
    [SerializeField] int nbOfCase;
    [SerializeField] Orientation orientation;
    int count = 0;
    [SerializeField]int tempo = 1;
    float time;
    int switchOrientation=1;

    public enum Orientation
    {
        Horizontale,
        Verticale
    }
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
        count += 1;
        if (count >= nbOfCase)
        {
            switchOrientation *= -1;
            count = 0;
        }
        if (orientation == Orientation.Horizontale)
        {
            transform.Translate(switchOrientation, 0, 1);
        }
        else 
        {
            transform.Translate(0, switchOrientation, 1);
        }
        
    }

}
