using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Ennemi : MonoBehaviour
{
    private Scr_TurnManager turnmanager;
    private Scr_EnnemiAi ai;

    public int esquive = 5;

    public int pv = 10;

    public int absorbance = 0;

    private void Awake()
    {
        turnmanager = FindObjectOfType<Scr_TurnManager>();
        ai = GetComponent<Scr_EnnemiAi>();
    }




    public void Turn()
    {
        ai.Move();
        turnmanager.EnemyEndTurn();
    }





}
