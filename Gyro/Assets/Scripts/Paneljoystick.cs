using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class Paneljoystick : MonoBehaviour, IPointerDownHandler
{
    public GameObject son;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public virtual void OnPointerDown(PointerEventData ped)
    {
        this.transform.position = ped.position;
        son.GetComponent<VirtualJoystick>().OnPointerDown(ped);

    }
    public virtual void OnDrag(PointerEventData ped)
    {
        son.GetComponent<VirtualJoystick>().OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {

        son.GetComponent<VirtualJoystick>().OnPointerUp(ped);

    }
}
