using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButton : MonoBehaviour {
	public static bool pressed = false;
	public static bool pressed2 = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (pressed == true) {
			GameObject go = GameObject.FindGameObjectWithTag ("MainCamera");
			Camera2 s = go.GetComponent<Camera2> ();
			s.trans ();
			Debug.Log ("pressed");
		} 
	}
	public void Up(){
		pressed = false;
	}
	public void LOl(){
		pressed = true;
	}


	public void Up2(){
		pressed2 = false;
	}
	public void down(){
		pressed2 = true;
	}


}
