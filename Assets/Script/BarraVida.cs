using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image barraVd;
    public float vidaActual;
    public float vidaMaxima;

    // Update is called once per frame
    void Update()
    {
        //barraVd.fillAmount = vidaActual / vidaMaxima;
    }

    public void restarVida(){
        vidaActual = vidaActual - 20;

        barraVd.fillAmount = vidaActual / vidaMaxima;

        Debug.Log("Vida actual :  " + vidaActual);
    }
}
