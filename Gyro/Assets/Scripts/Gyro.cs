using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour {
	private bool gryoenabled;
	private Gyroscope gyro;
	private GameObject cameracontainer;
	private Quaternion rot;
	private Quaternion root;

	// Use this for initialization
	void Start () {
		cameracontainer = new GameObject ("Camera Container");
		cameracontainer.transform.position = transform.position;
		transform.SetParent (cameracontainer.transform);
		gryoenabled = Enabled ();
		root = gyro.attitude * rot;
		transform.localRotation = new Quaternion (0.5f, -0.5f, 0.5f, -0.5f);

		
	}
	private bool Enabled(){
		if(SystemInfo.supportsGyroscope){
			gyro = Input.gyro;
			gyro.enabled = true;
			cameracontainer.transform.rotation = Quaternion.Euler (90f, 0f, 90f);
			rot = new Quaternion (0, 0, 1, 0);
			return true;
		}
		return false;
	}

	
	// Update is called once per frame
	private void Update () {
		if (gryoenabled) {
			Quaternion aux = gyro.attitude * rot;
			Quaternion dif = new Quaternion (-(aux.x - root.x),aux.y-root.y,-(aux.z-root.z),aux.w-root.w);

			Quaternion ss= new Quaternion (dif.x - 0.5f, dif.y + 0.5f, dif.z - 0.5f, dif.w + 0.5f);

			transform.localRotation = ss;

			Debug.Log (aux);
			Debug.Log (gyro.attitude * rot);

		}
		
	}
	public void button(){
		root = gyro.attitude * rot;
		transform.localRotation = new Quaternion (0.5f, -0.5f, 0.5f, -0.5f);
	}
}
