using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_EjeX : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    private float horizontal;
    // Start is called before the first frame update
    public float Speed;
    public float JumpForce;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        // almacena -1 si pulsamos tecla a
        // almacena 0 si no pulsamos nada
        // almacena 1 si pulsamos tecla d
        if(Input.GetKeyDown(KeyCode.W)){
            Jump();
        }
    }
    private void Jump()
    { 
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
    void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
    }
}
