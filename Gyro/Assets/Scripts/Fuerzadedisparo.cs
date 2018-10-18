using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuerzadedisparo : MonoBehaviour {
    [SerializeField]
    private float timer;
    private float aum = 0.1f;

    private bool stopc = true;
	// Use this for initialization
	void Start () {
        
    }
    public void start()
    {
        stopc = true;
        StartCoroutine(randomslider());
    }
    public void stop()
    {
        Debug.Log("Stop");
        stopc = false;
        StartCoroutine(disable());
    }
    IEnumerator disable()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
       
    }

   IEnumerator randomslider()
    {
        while (stopc)
        {

            if(GetComponent<Slider>().value >= 2.7 || GetComponent<Slider>().value <= 0.3)
            {
                aum = aum * -1;
            }
            GetComponent<Slider>().value += aum;
            yield return new WaitForSeconds(timer);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
