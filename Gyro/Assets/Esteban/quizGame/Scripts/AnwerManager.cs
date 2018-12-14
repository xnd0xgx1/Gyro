using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnwerManager : MonoBehaviour
{
    public bool _IsCorrect;
    public SlotInfo2 slotinfo2;
    public BD_Personaje personajeIMG;
    public Image icon2;
    public Sprite ajoBien;
    public Sprite ajoMal;
    public Image respuesta;
    [SerializeField]
    protected GameObject Gamehud;
    [SerializeField]
    protected GameObject Pausehud;



    public Button[] preguntasBotones;

    public void showpausemenu()
    {
        Gamehud.SetActive(false);
        Pausehud.SetActive(true);
    }
    public void showgamemenu()
    {
        Gamehud.SetActive(true);
        Pausehud.SetActive(false);
    }

    public void returnmundogyro()
    {
        PlayerPrefs.SetInt("load", 1);
        SceneManager.LoadScene(3);
    }

    private void Start()
    {
        UpdateUI();
    }
    
    IEnumerator ajolotl()
    {
        respuesta.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        respuesta.gameObject.SetActive(false);
        if (_IsCorrect)
        {
            _IsCorrect = false;
            UpdateUI();
        }
        for (int i = 0; i < 4; i++)
        {
            preguntasBotones[i].enabled = true;
        }


    }
    public void AnswerChecker(string name)
    {


        if (personajeIMG.FindAnswer(slotinfo2.itemId) == name)
        {

            respuesta.sprite = ajoBien;
         
            _IsCorrect = true;

        }

        else
        {
            respuesta.sprite = ajoMal;
            _IsCorrect = false;



        }
        for (int i = 0; i < 4; i++)
        {
            preguntasBotones[i].enabled = false;
        }

        StartCoroutine(ajolotl());

        
    }

        public void UpdateUI()     //update ui status
        {

        slotinfo2.itemId++;


        icon2.sprite = personajeIMG.FindPersonaje(slotinfo2.itemId);//looking for the sprite asigned into DataBase
                icon2.enabled = true;

                string[] tester = personajeIMG.FindString(slotinfo2.itemId);
        for (int i = 0; i < 4; i++)
        {
            preguntasBotones[i].transform.GetChild(0).GetComponent<Text>().text = tester[i];
            preguntasBotones[i].name = tester[i];
        }

    }
    [System.Serializable]
    public class SlotInfo2
    {
        public int id = -1;
         public int itemId;
        
    }


    }
