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


        for (int i = 0; i < capacite.Length; i++)
        {
            if (capacite[i].nom == "AttackCapa")
            {
                for (int j = 0; j < capaDataBase.AttackCapa[capacite[i].intCapa].attackCapa.Length; j++)
                {
                    //Debug.Log("Capa: " + capaDataBase.AutoCapa[capacite[i].intCapa].name);

                    if (capacite[i].uiCapaText)
                    {
                        capacite[i].uiCapaText.text = capaDataBase.AttackCapa[capacite[i].intCapa].name;
                    }
                    if (capacite[i].uiCapaAltText[j])
                    {
                        capacite[i].uiCapaAltText[j].text = capaDataBase.AttackCapa[capacite[i].intCapa].attackCapa[j].name;
                    }

                }
            }
            if (capacite[i].nom == "AutoCapa")
            {
                
                for (int j = 0; j < capaDataBase.AutoCapa[capacite[i].intCapa].autoCapa.Length; j++)
                {
                    //Debug.Log("Capa: " + capaDataBase.AutoCapa[capacite[i].intCapa].name);

                    if (capacite[i].uiCapaText)
                    {
                        capacite[i].uiCapaText.text = capaDataBase.AutoCapa[capacite[i].intCapa].name;
                    }
                    if (capacite[i].uiCapaAltText[j])
                    {
                        capacite[i].uiCapaAltText[j].text = capaDataBase.AutoCapa[capacite[i].intCapa].autoCapa[j].name;
                    }

                }

            }

        }






    }


}




