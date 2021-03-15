using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Capa : MonoBehaviour
{
    public Scr_AttackCapa[] attackCapa;

    public Text textCapa1;

    private void Start()
    {
        InitUi();
    }

    void InitUi()
    {
        if (textCapa1 != null)
        {
            textCapa1.text = attackCapa[0].name;
        }

    }

    public void Attack(int capacite)
    {
        attackCapa[capacite].Active();
    }



}
