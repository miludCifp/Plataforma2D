using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    private float horizontal;
    // Start is called before the first frame update
    public float Speed;
    public float JumpForce;
    public bool Grounded;
    private Animator Animator;
    public GameObject prefabBullet;

    private float LastShoot;
    private int Health = 100;


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
    
        ControlarDireccion();

        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f)){
            Grounded = true;
        }else{
            Grounded = false;
        }

        //Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);

        if(Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }

        //si el juegador pulsa tecla espacio
        //if(Input.GetKeyDown(KeyCode.Space)){
        //    Shoot();        
        //}

        //Deberá esperar un tiempo mayor para permitir disparar una segunda vez
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f){
            Shoot();  
            LastShoot = Time.time;
        }

    }
    private void Shoot(){
        // Pintamos el Prefab en scena, en la posición indicada y la rotación =0
        //Instantiate(prefabBullet,transform.position, Quaternion.identity);

        Vector3 direction;

        if ( transform.localScale.x == 1.0f ) direction = Vector3.right;
        else direction = Vector3.left;

        // Pintamos el Prefab en scena, en la posición indicada y la rotación=0
        // La posición se calcula: 
        // transform.position -> centro de John
        // direction *0.1f -> offset de desplazamiento
        GameObject bullet = Instantiate(prefabBullet,transform.position + direction * 0.1f, Quaternion.identity);

        bullet.GetComponent<BulletScript>().SetDirection(direction);

    }
    private void ControlarDireccion()
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

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        JohnMovement john = collision.collider.GetComponent<JohnMovement>();
        GruntMovement grunt = collision.collider.GetComponent<GruntMovement>();
        
    }
    */

    public void Hit(int daño){
        
        Health = Health - daño;

        GetComponent<BarraVida>().restarVida();

        Debug.Log("Me has golpeado ! "+ Health);

        if(Health <= 0) 
        {
            Debug.Log("Fin  "+ Health);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
    }
}
