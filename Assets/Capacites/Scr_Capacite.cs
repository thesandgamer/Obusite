using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Scr_Capacite
{
    public Text uiCapaText;
    public int intCapa;

    public Scr_Capacite(string nom, Text uiCapaText,int intCapa)
    {
        this.uiCapaText = uiCapaText;
        this.intCapa = intCapa;

    }
    

}
