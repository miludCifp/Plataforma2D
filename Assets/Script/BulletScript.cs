using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed = 2;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    // Start is called before the first frame update

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
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
}
