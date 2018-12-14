using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Personajes", fileName = "Personajes_")]

public class BD_Personaje : ScriptableObject
{

    public List<personajes> ToltalPersonajes = new List<personajes>();

    public Sprite FindPersonaje(int id)
    {
        foreach (personajes persona in ToltalPersonajes)
        {
            if (persona.id == id)
            {
                return persona.icon;
            }
        }
        return null;
    }

    public string[]  FindString(int id)
    {
        foreach (personajes persona in ToltalPersonajes)
        {
            if (persona.id == id)
            {
                return persona.preguntas;
            }
        }
        return null;
    }

    public string FindAnswer(int id)
    {
        foreach (personajes persona in ToltalPersonajes)
        {
            if (persona.id == id)
            {
                return persona.name;
            }
        }
        return null;
    }
}
[System.Serializable]
public class personajes
{
    public string name;
    public int id;
    public Sprite icon;
    public string[] preguntas;
}
