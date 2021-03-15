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

        
        for (int i = 0; i< capacite.Length; i++)
        { 
            for (int j = 0; j < capaDataBase.capa[capacite[i].intCapa].attackCapa.Length; j++)
            {
                /*
                Debug.Log("capa : " + capaDataBase.capa[i].name);
                Debug.Log("capa variation : " + capaDataBase.capa[i].attackCapa[j].name + " num�ro " + j);
                Debug.Log("capa : " + capaDataBase.capa[i].name);
                */
                if (capacite[i].uiCapaText)
                {
                    capacite[i].uiCapaText.text = capaDataBase.capa[capacite[i].intCapa].name;
                }
                if (capacite[i].uiCapaAltText[j])
                {
                    capacite[i].uiCapaAltText[j].text = capaDataBase.capa[capacite[i].intCapa].attackCapa[j].name;
                }     
                
            }

            
            
        }

    }


    



}
