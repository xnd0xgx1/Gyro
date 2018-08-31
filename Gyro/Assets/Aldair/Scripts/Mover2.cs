using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Mover2 : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IDragHandler
    {

    public Vector3 posActual;
    public Vector3 posInicial;
    public Vector3 posActualaux;
    public bool ronda;
  
    public float dis;

    private GameObject ambi;
   

   

    void Start()
    {

        posInicial = transform.position;
        
        ronda = true;
       
    }

   
    void Update()
    {
        posActual = transform.position;

    }

   

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (dis < 250)
        {
            transform.position = posInicial;
            
               this.gameObject.SetActive(false);
            
        }
        else
        {
            transform.position = posActualaux;
            //selva.SetActive(false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        dis = Vector3.Distance(posActual, posInicial);
        //dis = Vector3.Distance(posInicial, posActualaux);
        if (ronda == true)
        {
            posActualaux = transform.position;      
            ronda = false;
        }
        transform.position = Input.mousePosition;
    }
}
