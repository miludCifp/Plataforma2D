using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntMovement : MonoBehaviour
{
    public GameObject John;
    public GameObject BulletPrefab;
    private float LastShoot;
    private Rigidbody2D Rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = John.transform.position - transform.position;
        // Cambiamos la dirección del enemigo para que mire a donde esta John
        if( direction.x >= 0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);
        else transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
        // Recordad hacer un Freeze Rotation del eje Z para que no rote


        //Medimos la distancia entre los dos personajes
        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        // si la distancia es menor que 1 metro entonces permitimos al enemigo disparar
        // Le añadimos un delay tal como habíamos hecho con el disparo de John
        if (distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }


    }
    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    void FixedUpdate()
    {
        //Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
    }
}
