using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basura : MonoBehaviour
{

    [SerializeField]
    float max;

    Rigidbody Rig;

    void Start ()
    {

        Rig = GetComponent<Rigidbody>();

        Rig.AddForce(new Vector3 (Random.Range(-500,500),0,Random.Range(-500,500)));
      
       
	}
	
	void Update ()
    {
        Vector3 vel = Rig.velocity;
        if (vel.x >= max)
        {
            vel.x = max;
        }
        else if (vel.x <= -max)
        {
            vel.x = -max;
        }

        if (vel.z >= max)
        {
            vel.z = max;
        }
        else if (vel.z <= -max)
        {
            vel.z = -max;
        }


        Rig.velocity = vel;
    }
}
