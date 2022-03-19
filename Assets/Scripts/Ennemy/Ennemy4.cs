using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy4 : MonoBehaviour
{

    [SerializeField] int nbOfCase;
    [SerializeField] Orientation orientation;
    int count = 0;
    [SerializeField] int tempo = 1;
    float time;
    int switchOrientation = 1;
    float rotation;

    public enum Orientation
    {
        Horizontale,
        Verticale
    }
    void Start()
    {
        if (Random.Range(0, 1) == 0)
        {
            rotation = 22.5f;
        }
        else
        {
            rotation = -22.5f;
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

    void Rotation()
    {
        transform.rotation *= Quaternion.Euler(0, 0, rotation);
    }

}
