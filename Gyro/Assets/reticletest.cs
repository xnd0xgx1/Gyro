using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reticletest : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Radomlyteleport()
    {
        gameObject.transform.position = new Vector3(RANDOCOORDINATE(), Random.Range(0.5f, 2), RANDOCOORDINATE());
    }
    private float RANDOCOORDINATE()
    {
        var coordinate = Random.Range(-7, 7);
        while (coordinate > -1.5 && coordinate < 1.5)
        {
            coordinate = Random.Range(-5, 5);
        }
        return coordinate;
    }
}
