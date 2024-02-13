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
    public bool Grounded;
    private Animator Animator; 


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        // almacena -1 si pulsamos tecla a
        // almacena 0 si no pulsamos nada
        // almacena 1 si pulsamos tecla d

        Animator.SetBool("running", horizontal != 0.0f);

        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f)){
            Grounded = true;
        }else{
            Grounded = false;
        }

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);

        if(Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }

        controlarDireccion();
    }
    private void controlarDireccion()
    {
        // Controlamos la dirección donde mira el Personaje cuando
        // cambia de dirección izquierda o derecha
        if(horizontal < 0.0f) 
        {
            transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
            }
        else if (horizontal > 0.0f) 
        {
            transform.localScale = new Vector3(1.0f,1.0f,1.0f);
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
