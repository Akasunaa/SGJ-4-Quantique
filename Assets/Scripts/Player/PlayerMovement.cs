using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 10;
    float h_input;
    float v_input;
    bool canMove;
    float time;
    float tempo=1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //StartCoroutine(FreezePlayer(time));
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        GetInput();
        if (time >= tempo)
        {
            
            Deplacement();
            h_input = 0;
            v_input = 0;
            time = time % tempo;
        }

        //GetInput();
        //Deplacement();



    }

    void Intrication()
    {
        //mettre des paliers pour changer les sprites
    }
    void GetInput()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            v_input = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            v_input = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            h_input = 1;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            h_input = -1;
        }
    }
    void Deplacement()
    {
        transform.Translate(h_input, v_input, 1);
        
            
        //rb.velocity = new Vector2(h_input, v_input).normalized * speed;

    }

    private IEnumerator FreezePlayer(float time)
    {
        for(; ; )
        {
            canMove = false;
            yield return new WaitForSeconds(time);
            canMove = true;
            yield return new WaitForSeconds(time);
        }
        
    }
}
