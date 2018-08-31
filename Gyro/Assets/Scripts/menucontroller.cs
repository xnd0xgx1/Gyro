using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menucontroller : MonoBehaviour {

    public GameObject Drop;
    public GameObject buttons;

    private bool on = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void buttonclick()
    {
        if (on == false)
        {
            buttons.SetActive(false);
            Drop.SetActive(true);

        }
    }

    public void loadlvl()
    {
        PlayerPrefs.SetInt("load",1);
        SceneManager.LoadScene(3);
    }

}
