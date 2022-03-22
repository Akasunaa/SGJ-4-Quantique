using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy3 : Enemy
{
    public override void Deplacement()
    {
        int orientation = Random.Range(0, 2);
        if (orientation == 0)
        {
            int sens = Random.Range(-1, 2);
            DeplacementWithTile(new Vector2Int(0, sens));
        }
        else
        {
            int sens = Random.Range(-1, 2);
            DeplacementWithTile(new Vector2Int(sens, 0));
        }

    }

    public override void Rotation()
    {
        //do nothing
    }
}
