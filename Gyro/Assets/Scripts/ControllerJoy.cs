using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerJoy : MonoBehaviour {

    public GameObject cameras;
    private Vector3 dir;
    private Vector3 inputVector;
    public float speed;
    public Transform camtrans;
    private void Start()
    {
    }
    private void Update()
    {
        dir = Vector3.zero;
        dir.x = Horizontal();
        dir.z = Vertical();
        if (dir.magnitude > 1)
        {
            dir.Normalize();
        }
        dir = rotatewithview();
        cameras.GetComponent<Rigidbody>().AddForce(dir * speed);
    }
   
    public float Horizontal()
    {
            return Input.GetAxis("Horizontal");
        
    }

    public float Vertical()
    {
        
            return Input.GetAxis("Vertical");
        
    }
    private Vector3 rotatewithview()
    {
        if (camtrans != null)
        {
            Vector3 dd = camtrans.TransformDirection(dir);
            dd.Set(dd.x, 0, dd.z);
            return dd.normalized * dir.magnitude;
        }
        else
        {
            camtrans = Camera.main.transform;
            return dir;
        }


    }
}
