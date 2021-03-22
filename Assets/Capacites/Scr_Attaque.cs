using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scr_Attaque : MonoBehaviour
{
    public Scr_MovePositions posScript;
    int actualPosition;
    private Scr_Effets effets;

    [HideInInspector] public int modificateurValue;

    private void Start()
    {
        posScript = GetComponent<Scr_MovePositions>();
        effets = FindObjectOfType<Scr_Effets>();
    }

    public void CalculateIfMakeDamages(GameObject opponent, Scr_AttackCapa capacite, Transform selfPos, string part)
    {
        /*
        if (opponent.GetComponent<Scr_Ennemi>())
        {
            var ennemi = opponent.GetComponent<Scr_Ennemi>();
            int esquive = ennemi.esquive;
        }
        if (opponent.GetComponent<Scr_Player>())
        {
           var ennemi = opponent.GetComponent<Scr_Player>();
           int esquive = ennemi.esquive;
        }
        */

        if (opponent.GetComponent<Scr_TakeDamages>())
        {
            var ennemi = opponent.GetComponent<Scr_TakeDamages>();
            int esquive = ennemi.esquive;
        }

        int toReach = capacite.touche;
        int value = Random.Range(1, 100);
        Debug.Log("Position : " + selfPos);

        

        //Debug.Log("Portée taille: " + capacite.portee.Length);

        int modifTouchePortee = capacite.modifPortee[0];


        for (int i = 0; i <4; i++)
        {
            if (selfPos == posScript.pos[i])
            {
                actualPosition = i;
            }
        }

        Debug.Log("Valeur avant mofif: " + value);

        //Modifie la Touche en fonction de la position si elle à un modificateur
        value -= capacite.modifPortee[actualPosition];

        //Modifie la touche en fonction de la partie
        Debug.Log(part);
        switch (part)
        {
            case "Head":
                Debug.Log("Tête touchée");
                value -= 5;
                break;
            case "Torso":
                Debug.Log("Torce touchée");
                break;

        }

        value += modificateurValue;
        Debug.Log("Valeur après mofif: " + value);

        //Modifie la chance de saignement/... en fonction de la partie
        if (value <= toReach)
        {   
            opponent.GetComponent<Scr_TakeDamages>().TakeDamages(Random.Range(capacite.degats[0], capacite.degats[1]), part);
            effets.cible = opponent;
            capacite.effet.Invoke();
        }
        else
        {
            Debug.Log("Tir raté");
        }
        
    }

    public void CalculateIfTouch(GameObject cible, Scr_AutoCapa capacite)
    {
        int toReach = capacite.touche;
        int value = Random.Range(1, 100);

        if (value <= toReach)
        {
            effets.cible = cible;
            capacite.effet.Invoke();
        }



    }


}
