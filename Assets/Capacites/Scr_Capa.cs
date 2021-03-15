using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Capa : MonoBehaviour
{


    public Scr_CapaDataBase capaDataBase;
    public Scr_Capacite[] capacite;


    private void Start()
    {
        InitUi();
    }

    void InitUi()
    {
        for(int i = 0; i < capaDataBase.capa.Length; i++)
        {
            
            if (capacite[i].uiCapaText != null)
            {
                capacite[i].uiCapaText.text = capaDataBase.capa[capacite[i].intCapa].name;
            }
            
        }

        

    }



}
