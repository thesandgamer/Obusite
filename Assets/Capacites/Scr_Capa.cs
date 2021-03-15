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

        for (int i = 0; i < capaDataBase.capa.Length; i++)
        {

            if (capacite[i].uiCapaText != null)
            {
                capacite[i].uiCapaText.text = capaDataBase.capa[capacite[i].intCapa].name;

            }



        }
        
        for (int i = 0; i< capacite.Length; i++)
        { 
            for (int j = 0; j < capaDataBase.capa[capacite[i].intCapa].attackCapa.Length; j++)
            {
                Debug.Log("capa : " + capaDataBase.capa[i].name);
                Debug.Log("capa variation : " + capaDataBase.capa[i].attackCapa[j].name + " numéro " + j);
                //Debug.Log("capa : " + capaDataBase.capa[i].name);
                capacite[i].uiCapaAltText[j].text = capaDataBase.capa[capacite[i].intCapa].attackCapa[j].name;
            }

            
            
        }
        
       

        Debug.Log(capaDataBase.capa[capacite[0].intCapa].attackCapa[capacite[0].intCapa].name);


    }


    



}
