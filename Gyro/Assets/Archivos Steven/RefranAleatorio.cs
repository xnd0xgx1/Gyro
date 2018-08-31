using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RefranAleatorio : MonoBehaviour {

	public int seleccionador;
	public int tamanoArreglo = 10;
	public int[] posAleatoria = new int[3] {-270,0,270};
	public string[,] arregloRefran = new string[10, 4] {
		{ "ARROZ","SILLÓN","SALÓN","Nunca falta un negrito en el ________" },
		{ "MUERE","CRECE","SONRÍE","Hierba mala nunca ________" },
		{ "BOCA","MANO","NARIZ","Se metió en la ________ del lobo"  },
		{ "SORDO","CIEGO","MUDO", "No hay peor ________ que el que no quiere oír" },
		{ "PINTAN","COCINAN","MIRAN", "El león no es como lo ________" },
		{ "GARABATO","PERRO","OTRO GATO", "Con un ojo al gato y otro al ________" },
		{ "MONJE","HOMBRE","CAMINO", "El hábito no hace al ________" },
		{ "TIRO","GOLPE","CHANCLAZO", "Matar dos pájaros de un ________" },
		{ "ALEGRÍA","COMIDA","HAMBRE", "Barriga vacía, no tiene ________" },
		{ "TESORO","PERRO","REFRÁN", "Quien tiene un amigo tiene un ________" }
		//{ "", "" }
	};

	// Use this for initialization
	void Start () {
		seleccionarRefran ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void seleccionarRefran(){
		seleccionador = Random.Range (0, tamanoArreglo);

		GameObject refr = GameObject.Find ("RefranText");
		Text refran = refr.GetComponent<Text> ();
		refran.text = arregloRefran[seleccionador,3];

		GameObject txtObj = GameObject.Find ("Text1");
		Text txt = txtObj.GetComponent<Text> ();
		//		Vector3 pos = txtObj.GetComponent.transform.position;
		//		pos.x = 0.0f;
		txt.text = arregloRefran[seleccionador,0];

		GameObject txtObj2 = GameObject.Find ("Text2");
		Text txt2 = txtObj2.GetComponent<Text> ();
		txt2.text = arregloRefran[seleccionador,1];

		GameObject txtObj3 = GameObject.Find ("Text3");
		Text txt3 = txtObj3.GetComponent<Text> ();
		txt3.text = arregloRefran[seleccionador,2];

		GameObject button1 = GameObject.Find ("Button1");
		Vector3 pos1 = button1.transform.position;

		GameObject button2 = GameObject.Find ("Button2");
		Vector3 pos2 = button2.transform.position;

		GameObject button3 = GameObject.Find ("Button3");
		Vector3 pos3 = button3.transform.position;
//		pos.x = 200f;
//		button1.transform.position = pos;

		//---------------------------Poner los botones en posición aleaoria------------------------------------

		RectTransform rt1 = button1.GetComponent<RectTransform> ();
        RectTransform rt2 = button2.GetComponent<RectTransform>();
        RectTransform rt3 = button3.GetComponent<RectTransform>();

        int botonAleatorio = Random.Range (0, 3);// Determina la posición del primer botón
        int posiciones = Random.Range(0, 6);

        pos1 = rt1.anchoredPosition;
        pos2 = rt2.anchoredPosition;
        pos3 = rt3.anchoredPosition;

        pos1.x = posAleatoria[botonAleatorio];
		rt1.anchoredPosition = pos1;
        
        switch (posiciones)
        {
            case 0:
                pos1.x = -270;
                rt1.anchoredPosition = pos1;

                pos2.x = 0;
                rt2.anchoredPosition = pos2;

                pos3.x = 270;
                rt3.anchoredPosition = pos3;
                break;
            case 1:
                pos1.x = -270;
                rt1.anchoredPosition = pos1;

                pos2.x = 270;
                rt2.anchoredPosition = pos2;

                pos3.x = 0;
                rt3.anchoredPosition = pos3;
                break;
            case 2:
                pos1.x = 0;
                rt1.anchoredPosition = pos1;

                pos2.x = -270;
                rt2.anchoredPosition = pos2;

                pos3.x = 270;
                rt3.anchoredPosition = pos3;
                break;
            case 3:
                pos1.x = 0;
                rt1.anchoredPosition = pos1;

                pos2.x = 270;
                rt2.anchoredPosition = pos2;

                pos3.x = -270;
                rt3.anchoredPosition = pos3;
                break;
            case 4:
                pos1.x = 270;
                rt1.anchoredPosition = pos1;

                pos2.x = -270;
                rt2.anchoredPosition = pos2;

                pos3.x = 0;
                rt3.anchoredPosition = pos3;
                break;
            case 5:
                pos1.x = 270;
                rt1.anchoredPosition = pos1;

                pos2.x = 0;
                rt2.anchoredPosition = pos2;

                pos3.x = -270;
                rt3.anchoredPosition = pos3;
                break;
        }

		//while (true) {
			//Si el botón2 está en la posición del botón 1, se vuelve a activar el while, lo mismo con el botón 3 pero comparándolo con los 2 botones en vez de nada más 1
		//}
	}

	/*public void ChangeColour()
	{
		
		GameObject gobutton = GameObject.Find ("Button");
		Button centralButton = gobutton.GetComponent <Button> ();
		//centralButton.colors.normalColor=Color.green;
	}*/
    public void Index()
    {
        PlayerPrefs.SetInt("load", 1);
        SceneManager.LoadScene(3);
    }
}
