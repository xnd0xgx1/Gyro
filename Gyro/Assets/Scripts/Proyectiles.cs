using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Proyectiles : MonoBehaviour {

    private GameObject cmera;
    
    [SerializeField]
    private float fuerza;
    [SerializeField]
    private Slider slide;

    protected void spawn()
    {

        fuerza = slide.value*5.0f;
        RaycastHit rayhit;
        Physics.Raycast(cmera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out rayhit);
       
        
        Vector3 direccion = rayhit.point;
        Debug.Log(direccion);
        transform.LookAt(direccion);
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = transform.TransformDirection(new Vector3(0, 0, fuerza));
                   
    }
    // Use this for initialization
    void Start () {
        cmera = GameObject.FindGameObjectWithTag("MainCamera");
        slide = GameObject.FindGameObjectWithTag("fdisparo").GetComponent<Slider>();
        spawn();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
