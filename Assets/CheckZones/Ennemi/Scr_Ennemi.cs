using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Ennemi : MonoBehaviour
{
    private Scr_TurnManager turnmanager;
    private Scr_EnnemiAi ai;

    public bool turnFinish;


    private void Awake()
    {
        turnmanager = FindObjectOfType<Scr_TurnManager>();
        ai = GetComponent<Scr_EnnemiAi>();
    }


    public void CheckMoral()
    {
        int moral = GetComponent<Scr_TakeDamages>().moral;
        if (moral <= 0)
        {
            //Fuit le combat: x% chances de fuir ou fuite forcément?
            Fuite();
        }
    }

    public void Fuite()
    {

    }

    public void Turn()
    {
        ai.Attack();
        //turnmanager.EnemyEndTurn();
        turnFinish = true;
    }





}
