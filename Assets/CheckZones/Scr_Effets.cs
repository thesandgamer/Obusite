using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Effets : MonoBehaviour
{
    public GameObject cible;


    public void BaisseMorale(int value)
    {
        Debug.Log(cible.name +  " va avoir son moral baiss� de " + value);
    }

    public void Saignement(int dur�e)
    {
        cible.GetComponent<Scr_TakeDamages>().Saignement(dur�e);

    }



}
