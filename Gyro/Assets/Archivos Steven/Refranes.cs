using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refránes : MonoBehaviour {

	public int seleccionador;
	public int tamanoArreglo = 10;
	public string[] aleatoria = new string[3];
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
		seleccionador = Random.Range (0, tamanoArreglo);
//		int OpcionCorrecta = Random.Range (0, 3);
//		aleatoria [OpcionCorrecta] = arregloRefran [seleccionador, 0];
//		for (int i = 0; i < 3; i++) {
//			if (aleatoria [i] != null) {
//				aleatoria [i] = arregloRefran [seleccionador, i];
//			}
//		}

		//Pone en orden las opciones en los botones, dejando la opcion correcta en el botón 1 y las incorrectas en los demas

		GameObject txtObj = GameObject.Find ("Button1");
		Text txt = txtObj.GetComponent<Text> ();
		txt.text = arregloRefran[seleccionador,0];

		GameObject txtObj2 = GameObject.Find ("Button2");
		Text txt2 = txtObj2.GetComponent<Text> ();
		txt2.text = arregloRefran[seleccionador,1];

		GameObject txtObj3 = GameObject.Find ("Button3");
		Text txt3 = txtObj3.GetComponent<Text> ();
		txt3.text = arregloRefran[seleccionador,2];


		StartCoroutine ("SpawnRefran");
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator SpawnRefrán(){
		yield return new WaitForSeconds (5);
		while(true){
			
		}
	}
}
