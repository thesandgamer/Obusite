using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_TakeDamages : MonoBehaviour
{

    public int pv = 10;
    public int esquive = 5;
    public int absorbance = 0;


    public bool saignement = false;
    public int dureeSaignement;


    public void TakeDamages(int damages)
    {
        if (pv > 0)
        {
            pv -= damages - absorbance;
            Debug.Log("PV = " + pv);
            if (damages - absorbance > pv)
            {
                Dead();
            }

        }

    }

    public void Dead()
    {
        Debug.Log("Dead");
    }

    public void Turn()
    {
        if (saignement)
        {
            if (dureeSaignement >0)
            {
                dureeSaignement--;
                pv -= 1;
            }
            else
            {
                saignement = false;
            }
            
        }


    }

    //
    public void Saignement(int durée)
    {
        saignement = true;
        dureeSaignement = durée;
    }




}
