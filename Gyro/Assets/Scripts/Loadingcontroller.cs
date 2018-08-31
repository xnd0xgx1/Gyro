using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;



public class Loadingcontroller : MonoBehaviour {
    public Text loadingText;
    AsyncOperation async;
    private bool playing = false;
    private bool playing1 = false;
    public Slider slider;
    private VideoPlayer vp;
    
    private float ff = 0f;
	// Use this for initialization
	void Start () {
        vp = GetComponent<VideoPlayer>();
        vp.waitForFirstFrame = true;

        


    }


    IEnumerator vid()
    {
        while (ff <= 1f)
        {   
            yield return new WaitForSeconds(0.1f);
            slider.value = slider.value + 0.08f;
            ff += 0.08f; 
           
        }
        

    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(3.1f);
        
        async = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("load"));
        
        while (!async.isDone)
        {
           
            yield return null;
            
        }
    }
	
	// Update is called once per frame
	void Update () {
        loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
       if (vp.isPlaying && playing == false)
        {
            StartCoroutine("vid");
            StartCoroutine("Load");
            playing = true;
       }
        if((float)vp.frame/(float)vp.frameCount>= 0.8f && playing1 == false)
        {
            vp.Pause();
            playing1 = true;
        }
        
    }
}
