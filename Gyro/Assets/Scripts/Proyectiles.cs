using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectiles : MonoBehaviour {

    [SerializeField]
    private float fuerza;

    protected void spawn()
    {
        Vector3 direccion = this.transform.eulerAngles;
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = transform.TransformDirection(new Vector3(0, 0, fuerza));
                   
    }
    // Use this for initialization
    void Start () {
        spawn();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
