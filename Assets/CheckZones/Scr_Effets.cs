using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Effets : MonoBehaviour
{
    public GameObject cible;


    public void BaisseMorale(int value)
    {
        Debug.Log("Perte moral : " + value + " à " + cible);
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].moral -= value;
    }

    public void GainMoral(int value)
    {
        Debug.Log("Gain moral : " + value + " à " + cible);
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].moral += value;
    }


    public void Saignement(int durée)
    {
        cible.GetComponent<Scr_TakeDamages>().Saignement(durée);
    }

    public void Stun()
    {
        Debug.Log(cible.name + " va être stun");
        cible.GetComponent<Scr_TakeDamages>().Stun();
    }

    public void Viser(int value)
    {
        //Au tour suivant la cible aura +x en touche
        Debug.Log("Viser");
        cible.GetComponentsInChildren<Scr_Attaque>()[0].modificateurValue += value;
    }

    public void PerteTouche(int value)
    {
        //Au tour suivant la cible aura -x en touche
        Debug.Log("Moins de chances de toucher");
        cible.GetComponentsInChildren<Scr_Attaque>()[0].modificateurValue -= value;
    }


    public void PerteEsquive(int value)
    {
        //Au tour suivant la cible aura -x en esquive
        Debug.Log("Perte de " + value + " d'esquive ");
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].esquive -= value;
    }

    public void GainEsquive(int value)
    {
        //Au tour suivant la cible aura +x en esquive
        Debug.Log("Gain de " + value + " d'esquive ");
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].esquive += value;
    }

    public void ContreAttaque()
    {
        Debug.Log("Peut faire une Contre atttaque");

    }

    public void DegatsMortel(int percent)
    {
        //Si l'effet réussit met à 0 les pv de son adversaire
        Debug.Log(percent + "% de chances de tuer instant la cible ");
    }

    public void GainAbsorbance(int value)
    {
        Debug.Log("Gain de " + value + " d'absorbance ");
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].absorbance += value;
    }   
    
    public void PerteAbsorbance(int value)
    {
        Debug.Log("Perte de " + value + " d'absorbance ");
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].absorbance -= value;

    }






}
