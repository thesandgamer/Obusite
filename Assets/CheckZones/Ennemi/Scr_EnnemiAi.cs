using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnnemiAi : MonoBehaviour
{
    private Scr_MovePositions posManager;
    private Scr_Capa capaManager;
    private Scr_Attaque attaqueManager;

    public GameObject player;

    private void Awake()
    {
        posManager = GetComponent<Scr_MovePositions>();
        capaManager = GetComponent<Scr_Capa>();
        attaqueManager = GetComponent<Scr_Attaque>();
    }


    public void Move()
    {
        int i = Random.Range(0, 4);
        //D�tecter o� on est 
        //Prendre un autre num�ro si le num�ro est le m�me que l� o� on est
        posManager.MoveToPosition(posManager.pos[i]);
    }

    public void ChooseCapa()
    {

    }

    public void Attack()
    {
        attaqueManager.CalculateIfMakeDamages(player, capaManager.attackCapa[0],posManager.actualPosition,"Head") ;

    }

}
