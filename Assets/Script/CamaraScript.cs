using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    public GameObject John;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Si John esta muerto, return
        if(John == null){
            return;
        }

        Vector3 position = transform.position;
        position.x = John.transform.position.x;
        transform.position = position;
    }
}
