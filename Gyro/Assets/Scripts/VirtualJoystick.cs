using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;


public class VirtualJoystick : MonoBehaviour, IDragHandler,IPointerUpHandler,IPointerDownHandler
{
	public GameObject cameras;
	private Image	bgImg;
	private Image joyimg;
	private Vector3 dir;
	private Vector3 inputVector;
	public float speed;
	public Transform camtrans;
	private void Start(){
		bgImg = GetComponent<Image>();
		joyimg = transform.GetChild (0).GetComponent<Image> ();
	}
	private void Update(){
		dir = Vector3.zero;
		dir.x = Horizontal ();
		dir.z = Vertical ();
		if (dir.magnitude > 1) {
			dir.Normalize ();
		}
		dir = rotatewithview ();
		cameras.GetComponent<Rigidbody> ().AddForce (dir * speed);
	}
	public virtual void OnDrag(PointerEventData ped){
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y/ bgImg.rectTransform.sizeDelta.y);
			inputVector = new Vector3 (pos.x*2+1, 0, pos.y*2-1);
			inputVector = (inputVector.magnitude>1.0f)?inputVector.normalized:inputVector;
			joyimg.rectTransform.anchoredPosition = new Vector3 (inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3), inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
		
		}
	}
	public virtual void OnPointerDown(PointerEventData ped){
        StopAllCoroutines();
        this.transform.position = ped.position;
        GetComponent<CanvasGroup>().alpha = 1;
        OnDrag (ped);

	}
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<CanvasGroup>().alpha = 0;
        this.transform.localPosition = Vector3.zero;
    }
	public virtual void OnPointerUp(PointerEventData ped){
        StartCoroutine("waiter");
        
		inputVector = Vector3.zero;
		joyimg.rectTransform.anchoredPosition = Vector3.zero;
        
        
    }
	public float Horizontal(){
		if (inputVector.x != 0) {
			return inputVector.x;
		} else {
			return Input.GetAxis ("Horizontal");
		}
	}

	public float Vertical(){
		if (inputVector.z != 0) {
			return inputVector.z;
		} else {
			return Input.GetAxis ("Vertical");
		}
	}
	private Vector3 rotatewithview(){
		if (camtrans != null) {
			Vector3 dd = camtrans.TransformDirection (dir);
			dd.Set (dd.x, 0, dd.z);
			return dd.normalized * dir.magnitude;
		} else {
			camtrans = Camera.main.transform;
			return dir;
		}


	}
}
