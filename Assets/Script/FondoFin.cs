using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoFin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        JohnMovement john = collider.GetComponent<JohnMovement>();
        //GruntMovement grunt = collider.GetComponent<GruntMovement>();

        if(john != null){ //hemos impactado con john
            john.Hit(999);
        }
        
    }
}
