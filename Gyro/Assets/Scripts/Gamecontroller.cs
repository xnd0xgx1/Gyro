﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class Gamecontroller : MonoBehaviour {
    public GameObject pause;
    public GameObject game;

    public GameObject pausevr;
    public GameObject gamevr;

    public GameObject options;
    public GameObject call;

    public GameObject callvr;
    public GameObject optionsvr;

    public GameObject minijuegos;


    public GameObject vr;
    public GameObject ddd;

    private bool xr = true;
    
    // Use this for initialization
    void Start() {
        
        if(vr.activeSelf)
        {
            xr = false;
        }
    }

    // Update is called once per frame
    void Update() {

    }
    public void Pause() {
        if (xr == false)
        {

            pausevr.SetActive(true);
            gamevr.SetActive(false);
        }
        else
        {
            pause.SetActive(true);
            game.SetActive(false);
        }
        

    }

   
    public void change(){
        if (xr == false)
        {

            callvr.SetActive(false);
            optionsvr.SetActive(true);
        }
        else
        {
            call.SetActive(false);
            options.SetActive(true);
        }

    }

    public void rev()
    {
        if (xr == false)
        {

            callvr.SetActive(true);
            optionsvr.SetActive(false);
        }
        else
        {
            call.SetActive(true);
            options.SetActive(false);
        }

        

    }

    public void Resume(){
        if (xr == false)
        {

            pausevr.SetActive(false);
            gamevr.SetActive(true);
        }
        else
        {
            pause.SetActive(false);
            game.SetActive(true);
        }
        
	}
    public void Changescenerefranes()
    {
        PlayerPrefs.SetInt("load", 4);
        SceneManager.LoadScene(3);
    }

    public void Changescene()
    {
        PlayerPrefs.SetInt("load", 2);
        SceneManager.LoadScene(3);
    }

    public void Changesceneclima()
    {
        PlayerPrefs.SetInt("load", 5);
        SceneManager.LoadScene(3);
    }

    public void changevr()
    {
        if (xr == false)
        {

            vr.SetActive(false);
            ddd.SetActive(true);
            StartCoroutine("LoadDevice0");
        }
        else
        {
            vr.SetActive(true);
            ddd.SetActive(false);
            StartCoroutine("LoadDevice");
        }
        
        

        
    }

    public void minijuego()
    {
        
            minijuegos.SetActive(true);
            pause.SetActive(false);
        
    }

    public void back()
    {

        minijuegos.SetActive(false);
        pause.SetActive(true);

    }

    IEnumerator LoadDevice0()
    {
        XRSettings.LoadDeviceByName("none");
        xr = true;
        yield return null;
        XRSettings.enabled = true;
    }

    IEnumerator LoadDevice()
    {
        XRSettings.LoadDeviceByName("cardboard");
        xr = false;
        yield return null;
        XRSettings.enabled = true;
    }
}



