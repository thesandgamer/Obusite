using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Scr_CapaAll 
{
    public string name;
    public Scr_AttackCapa[] attackCapa;

    public Scr_CapaAll(string name, Scr_AttackCapa[] attackCapa)
    {
        this.name = name;
        this.attackCapa = attackCapa;
    }


}
