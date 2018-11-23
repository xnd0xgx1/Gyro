using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gancho : MonoBehaviour


{

    public Text CoutRecoleccion;

    public GameObject controller;
    public int Dir = 1;
    public bool iniciado = false;

    public int BasurasColectadas = 0;

    void Start ()
    {
        
	}
	void Update ()
    {
        if (iniciado)
        {
            MovDir();
        }
        if (transform.position.y >= 18 && iniciado == true)
        {
            iniciado = false;
            controller.GetComponent<Game>().activegancho = false;
            Dir *= -1;

        }
	}

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("Basura") )
        {
            Col.gameObject.SetActive(false);
            BasurasColectadas++;
            CoutRecoleccion.text = "" + BasurasColectadas;
            Dir *= -1;
        }
        if (Col.gameObject.CompareTag("piso"))
        {
            Dir *= -1;
        }
    }

    void MovDir()
    {
        Vector3 Pos = transform.position;
        Pos.y -= 0.5f*Dir;
        transform.position = Pos;
    }

}
