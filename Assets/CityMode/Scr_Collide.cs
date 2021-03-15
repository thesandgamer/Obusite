using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Collide : MonoBehaviour
{
    public GameObject collide;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (collide.GetComponent<Scr_TurnManager>())
            {
                collide.GetComponent<Scr_TurnManager>().SetupBattle();

            }

        }

    }



}
