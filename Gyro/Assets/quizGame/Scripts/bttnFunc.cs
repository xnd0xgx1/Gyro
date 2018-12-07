using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bttnFunc : MonoBehaviour {



    public void ButtonFunc()
    {

        GameObject controller = GameObject.FindGameObjectWithTag("GameController");

        controller.GetComponent<AnwerManager>().AnswerChecker(this.name);

    }
}
