using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Capa : MonoBehaviour
{


    public Scr_CapaDataBase capaDataBase;
    public Scr_Capacite[] capacite;
    public Scr_Capacite[] autoCapacite;


    private void Start()
    {
        if (!gameObject.CompareTag("Ennemi"))
        {
            InitUi();
        }
          
        
    }

    void Update()
    {
        if (!gameObject.CompareTag("Ennemi"))
        {
            InitUi();
        }
    }

    void InitUi()
    {


        for (int i = 0; i < capacite.Length; i++)
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

        for (int i = 0; i < autoCapacite.Length; i++)
        {

            for (int j = 0; j < capaDataBase.AutoCapa[autoCapacite[i].intCapa].autoCapa.Length; j++)
            {
                //Debug.Log("Capa: " + capaDataBase.AutoCapa[capacite[i].intCapa].name);

                if (autoCapacite[i].uiCapaText)
                {
                    autoCapacite[i].uiCapaText.text = capaDataBase.AutoCapa[autoCapacite[i].intCapa].name;
                }
                if (autoCapacite[i].uiCapaAltText[j])
                {
                    autoCapacite[i].uiCapaAltText[j].text = capaDataBase.AutoCapa[autoCapacite[i].intCapa].autoCapa[j].name;
                }

            }

        }

    }






}







