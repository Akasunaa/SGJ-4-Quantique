using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy2 : Enemy
{ 
    float rotation;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            rotation = 45f;
        }
        else
        {
            rotation = -45f;
        }
    }


    public override void Deplacement()
    {
        int orientation = Random.Range(0,2);
        if (orientation == 0)
        {
            int sens = Random.Range(-1, 2);
            //DeplacementWithTile(new Vector2Int(0, sens));
        }
        else
        {
            int sens = Random.Range(-1, 2);
            DeplacementWithTile(new Vector2Int(sens, 0));
        }
        //Rotation();
    }

    public override void Rotation()
    {
        RotationWithTile(rotation);
    }


}
