using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{

    public GameObject Pausehud;
    public GameObject Gamehud;

    public Camera MainCmaera;
    public GameObject Gancho2;
    public GameObject Basura;

    public Text CoutBasuras;
    
    public Text CoutNivel;

    Vector3 Pos;

    public int NoBasuras;
    public int Nivel = 1;
    public int Vueltas = 1;

    public bool activegancho = false;
    public bool NivelTerminado = false;

    void Start()
    {
        NoBasuras = 5;
        StartCoroutine("Basuras");
    }

    void Update()
    {
        if (!activegancho)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = MainCmaera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Basura")
                    {
                        Vector3 Diferencia = hit.transform.position;
                        Diferencia.y = 17;
                        Gancho2.transform.position = Diferencia;
                        activegancho = true;
                        Gancho2.GetComponent<Gancho>().iniciado = true;
                    }
                }
            }
        }
    }

    IEnumerator Basuras()
    {
        CoutNivel.text = "" + Nivel;
        CoutBasuras.text = "" + NoBasuras; 
        //Debug.Log("Se inicio Cortina");
        //Debug.Log("NoBasuras: " + NoBasuras);
        for (; Vueltas <= NoBasuras && NivelTerminado == false ; Vueltas++)
        {
            //Debug.Log("Basura: " + Vueltas);
            float PosX = Random.Range(-17, 15);
            Pos = transform.position;
            Pos.x = PosX;
            Instantiate(Basura, Pos, Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
        //Debug.Log("Salio del for");
        yield return new WaitForSeconds(10.0f);
        SigNivel();
    }

    public void SigNivel()
    {
        NoBasuras += 5;
        Nivel++;
        //Debug.Log("Nivel: "+ Nivel);
        //Debug.Log("NoBasuras: " + NoBasuras);
        Vueltas = 1;
        StartCoroutine("Basuras");
    }

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
}
