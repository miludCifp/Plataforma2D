using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    public AudioClip sonido;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDirection(Vector2 direction){
		Direction = direction;
    }
    private void FixedUpdate()
    {
        //Rigidbody2D.velocity = Vector2.right * Speed;
        Rigidbody2D.velocity = Direction * Speed;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    // Se lanza cada vez que el objeto Bullet/Bala colisione
    void OnTriggerEnter2D(Collider2D collider)
    {
        JohnMovement john = collider.GetComponent<JohnMovement>();
        GruntMovement grunt = collider.GetComponent<GruntMovement>();


        if(john != null){ //hemos impactado con john
            john.Hit(20);
        }

        if(grunt != null){//hemos impactado con grunt
            grunt.Hit();
        }

        DestroyBullet();
        
    }

}
