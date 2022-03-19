using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 10;
    float h_input;
    float v_input;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        v_input = 0;
        h_input = 0;
        Deplacement();

    }

    void Deplacement()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            v_input += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            v_input -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            h_input += 1;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            h_input -= 1;
        }
        rb.velocity = new Vector2(h_input, v_input).normalized * speed;

    }
}
