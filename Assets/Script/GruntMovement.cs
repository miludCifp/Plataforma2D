using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntMovement : MonoBehaviour
{
    public GameObject John;
    private Rigidbody2D Rigidbody2D;
    private float horizontal;

    // Start is called before the first frame update
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


        Vector3 direction = John.transform.position - transform.position;
        // Cambiamos la dirección del enemigo para que mire a donde esta John
        if( direction.x >= 0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);
        else transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
        // Recordad hacer un Freeze Rotation del eje Z para que no rote
    }
    void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
    }
}
