using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Mover : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IDragHandler
    {

    public Vector3 posActual;
    public Vector3 posInicial;
    public Vector3 posActualaux;
    public bool ronda;
    public bool Acierto =  false;
    public float dis;

    public GameObject Bas;

    GameController gam;

    // Use this for initialization

    void Start()
    {

        posInicial = transform.position;
        //GameObject gm = Instantiate(Bas, posInicial, Quaternion.identity) as GameObject;
        //gm.transform.SetParent(this.transform);
        //Instantiate(Bas, posInicial, Quaternion.identity);
        ronda = true;

    }

    // Update is called once per frame
    void Update()
    {
        posActual = transform.position;

    }

    public void drag()
    {
         
    }

    public void drop()
    {

       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (dis < 10)
        {
            transform.position = posInicial;
        }
        else
        {
            transform.position = posActualaux;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        dis = Vector3.Distance(posActual, posInicial);
        Debug.Log(dis);
        if (ronda == true)
        {
            posActualaux = transform.position;      
            ronda = false;
        }
        transform.position = Input.mousePosition;
    }
}
