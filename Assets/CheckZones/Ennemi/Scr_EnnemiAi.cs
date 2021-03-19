using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnnemiAi : MonoBehaviour
{
    private Scr_MovePositions posManager;
    private Scr_Capa capaManager;
    private Scr_CapaDataBase dataBase;
    private Scr_Attaque attaqueManager;

    public GameObject player;

    private void Awake()
    {
        posManager = GetComponent<Scr_MovePositions>();
        capaManager = GetComponent<Scr_Capa>();
        attaqueManager = GetComponent<Scr_Attaque>();
        dataBase = FindObjectOfType<Scr_CapaDataBase>();
    }


    public void Move()
    {

        //Détecter où on est 

        //Prendre un numéro au pif
        int i = Random.Range(0, 4);
        //Prendre un autre numéro si le numéro est le même que là où on est
        i = Random.Range(0, 4);
        //Déplacer à la position du numéro
        posManager.MoveToPosition(posManager.pos[i]);

        if (posManager.actualPosition != posManager.pos[i])
        {
            
        }





    }

    public void ChooseCapa()
    {

    }

    public void Attack()
    {
        attaqueManager.CalculateIfMakeDamages(player, dataBase.AttackCapa[0].attackCapa[0],posManager.actualPosition,"Head") ;

    }

}
