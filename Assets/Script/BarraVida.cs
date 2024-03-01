using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image barraVd;
    public float vidaActual;
    public float vidaMaxima;

    public Text txtVidaActual;

    // Update is called once per frame
    void Update()
    {
        //barraVd.fillAmount = vidaActual / vidaMaxima;
    }

/*
    public void restarVida(){
        vidaActual = vidaActual - 20;

        float vdActual = barraVd.fillAmount = vidaActual / vidaMaxima;

        // Cargar aqui la vida actual en el objeto Text

        txtVidaActual = FindObjectOfType<TxtVidaActual>();

        txtVidaActual.Text(vdActual.toString());


        Debug.Log("Vida actual :  " + vidaActual);
    }
    */



    public void restarVida()
    {
        vidaActual -= 20f;
        float vdActual = vidaActual / vidaMaxima;
        barraVd.fillAmount = vdActual;

        // Cargar aquí la vida actual en el objeto Text
        txtVidaActual.text = "Vida actual: " + vidaActual.ToString();

        Debug.Log("Vida actual: " + vidaActual);
    }
}
