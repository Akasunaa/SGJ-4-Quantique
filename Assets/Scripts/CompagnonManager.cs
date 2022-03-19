using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompagnonManager : MonoBehaviour
{
    PlayerIntrication player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerIntrication>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.intrication == 0)
        {
            print("pas très fort");
        }
    }
}
