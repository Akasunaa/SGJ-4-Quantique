using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehavior : MonoBehaviour
{
    [SerializeField] int damage;

    private void Awake()
    {
        Zone.NewZone += ChangeTempo;
    }

    private void OnDestroy()
    {
        Zone.NewZone -= ChangeTempo;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    void ChangeTempo(int nbZone)
    {
        //rahoui je vais coder ça
    }

}
