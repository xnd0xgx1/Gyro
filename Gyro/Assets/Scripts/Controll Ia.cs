using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllIa : MonoBehaviour {
	public enum estado {patrullaje,llamado,hambriento,dormir,bañado,Pelota}
	public estado actualestate;
	
	public GameObject target;
	public Transform[] waypoints;



	// Use this for initialization
	protected virtual void Start () {


	}
	protected abstract void estadopatrullaje();
	protected abstract void Estadollamado();
    protected abstract void estadohambriento();
    protected abstract void Estadodormir();
    protected abstract void EstadoBañar();
    protected abstract void Estadobuscarpelota();


    // Update is called once per frame
    void Update () {

	}
}
