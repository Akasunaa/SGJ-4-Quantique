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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerIntrication>().intrication -= damage;
            print("JETENIQUE");
        }
    }

    void ChangeTempo(int nbZone)
    {
        //changesmth
    }

}
