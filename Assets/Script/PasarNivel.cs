using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour
{
    public void MetodoPasarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        JohnMovement john = collider.GetComponent<JohnMovement>();


        if(john != null){ //hemos impactado con john
            MetodoPasarNivel();
        }
    }

}
