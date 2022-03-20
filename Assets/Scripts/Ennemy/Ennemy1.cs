using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy1: Enemy
{
    
    [SerializeField] int nbOfCase;
    [SerializeField] Orientation orientation;
    int count = 0;


    int switchOrientation=1;

    public enum Orientation
    {
        Horizontale,
        Verticale
    }
 
    public override void Deplacement()
    {
        count += 1;
        if (count >= nbOfCase)
        {
            switchOrientation *= -1;
            count = 0;
        }
        if (orientation == Orientation.Horizontale)
        {
            DeplacementWithTile(new Vector2Int(switchOrientation, 0));
        }
        else 
        {
            DeplacementWithTile(new Vector2Int(0, switchOrientation));
        }
        
    }

}
