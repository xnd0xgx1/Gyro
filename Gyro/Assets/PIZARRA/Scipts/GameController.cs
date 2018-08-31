//Script que controlara las posiciones de todos los estados, elijiendo cuales seran los estados que se moveran

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

    public int NumEstadosDesordenados = 3; //probicional puede variar de 3 a 5

    public Text[] Std;

    public Image[] StdImg;

    int[] Seleccion = new int[5];

    //public GameObject[] NombresEstados;

    // Un arreglo de cadenas donde contiene todos los estados y cada estado tiene un número asignado
    string[,] Estados = new string[,] { { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10","11", "12", "13", "14", "15", "16", "17", "18", "19", "20","21", "22", "23", "24", "25", "26","27"}, 
                                         {"BajaCaliforniaNorte","BajaCaliforniaSur","Campeche","Chihuahua","Chiapas","Coahuila","Durango","Guanajuato","Guerrero","Hidalgo","jalisco","Mexico","Michoacan","Nayarit","NuevoLeon","Oaxaca","puebla","Queretaro","QuintanaRoo","SanLuisPotosi","Sinaloa","Sonora","Tabasco","Tamaulipas","Veracruz","Yucatan","Zacatecas"} };


    void Start()
    {
       StartCoroutine ("inicio");
    }

    public void mover()
    {
        bool Elegido = false;

        for (int i = 0; i < NumEstadosDesordenados; i++)
        {
            int EdoElegido = Random.Range(0, 26);
            for (int x = 0; x < NumEstadosDesordenados; x++)
            {
                if (EdoElegido == Seleccion[x])
                {
                    Elegido = true;
                    i--;
                    break;
                }
                else
                {
                    Elegido = false;
                }
            }
            if (Elegido == false)
            {
                Std[i].text = "Estado: " + Estados[1, EdoElegido];
                Seleccion[i] = EdoElegido;
                Vector3 pos = new Vector3(0, 40, 0);
                switch (i)
                {
                    case 0:
                        StdImg[EdoElegido].transform.position = Std[i].transform.position - pos;
                        StdImg[EdoElegido].color = Color.green;
                        break;
                    case 1:
                        StdImg[EdoElegido].transform.position = Std[i].transform.position - pos;
                        StdImg[EdoElegido].color = Color.green;
                        break;
                    case 2:
                        StdImg[EdoElegido].transform.position = Std[i].transform.position - pos;
                        StdImg[EdoElegido].color = Color.green;
                        break;
                    case 3:
                        StdImg[EdoElegido].transform.position = Std[i].transform.position - pos;
                        StdImg[EdoElegido].color = Color.green;
                        break;
                    case 4:
                        StdImg[EdoElegido].transform.position = Std[i].transform.position - pos;
                        StdImg[EdoElegido].color = Color.green;
                        break;
                }
            }
        }
    }
    IEnumerator inicio()
    {
        yield return new WaitForSeconds(2.0f);
        mover();
        StopCoroutine ("inicio");
    }

    public void regresar()
    {
        SceneManager.LoadScene("pizzarra");
    }
    public void index()
    {
        PlayerPrefs.SetInt("load", 1);
        SceneManager.LoadScene(3);
    }

    void Update ()
    {

    }
}
