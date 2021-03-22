using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_TakeDamages : MonoBehaviour
{

    [Header("Base")]
    public int basePv = 10;
    public int baseEsquive = 5;
    public int baseAbsorbance = 0;
    private int moralMax = 20;

    [HideInInspector] public int pv;
    [HideInInspector] public int esquive;
    [HideInInspector] public int absorbance;
    public int moral = 10;

    public bool saignement = false;
    [HideInInspector] public int dureeSaignement;
    public bool stun = false;
    public bool dead = false;

    private Scr_Attaque attaqueManager;

    public void Start()
    {
        pv = basePv;
        esquive = baseEsquive;
        absorbance = baseAbsorbance;
        attaqueManager = GetComponent<Scr_Attaque>();
    }

    public void TakeDamages(int damages,string part)
    {
        if (pv > 0)
        {
            int damageTaken = damages;
            switch (part)
            {
                case "Head":
                    pv -= damages - absorbance;
                    damageTaken = damages - absorbance;
                    break;
                case "Torso":
                    pv -= damages - absorbance + 2;
                    damageTaken = damages - absorbance+2;
                    break;

            }
            
            Debug.Log("PV = " + pv);
            if (damageTaken > pv)
            {
                Dead();
            }

        }

    }

    public void Dead()
    {
        Debug.LogError(name + " est mort");
    }


    public void Turn()
    {
        ResetValue();
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


    public void Stun()
    {
        stun = true;
    }

    public void ResetValue()
    {
        stun = false;
        esquive = baseEsquive;
        absorbance = baseAbsorbance;
        attaqueManager.modificateurValue = 0;

    }



}
