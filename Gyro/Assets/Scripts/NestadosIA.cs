using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NestadosIA : MonoBehaviour {

    public Slider BarraHambre;
    public Slider BarraVida;
    public Slider BarraBaño;
    public Slider BarraSueño;

    public GameObject Pet;

    public float RestaHambre;
    public float RestaVida;
    public float RestaBaño;
    public float RestaSueño;

	void Start ()
    {
        StartCoroutine("DisHambre");
    }
	
	void Update ()
    {
        //if (BarraSueño.value <= 10)Pet.GetComponent<AiPet>().actiondormir();            
        if (BarraHambre.value <= 40) { Pet.GetComponent<AiPet>().actionhambre(); } else
        {
           // Pet.GetComponent<AiPet>().call() ;
        }
       
        if (BarraHambre.value <= 0)
        {
            
            RestaVida = 2.0f;
        }
        else
        {
            RestaVida = 0;
        }
	}

    IEnumerator DisHambre ()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            BarraHambre.value -= RestaHambre;
            BarraVida.value -= RestaVida;
            BarraSueño.value -= RestaSueño;
            BarraBaño.value -= RestaBaño;
        }
    }
}
