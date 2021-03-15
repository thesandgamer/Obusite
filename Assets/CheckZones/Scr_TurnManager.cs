using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN,ENEMYTURN,WON,TURN }

public class Scr_TurnManager : MonoBehaviour
{
    public BattleState state;

    public GameObject player;
    public GameObject[] enemy;

    [Header ("Cameras")]
    public Camera battleCamera;
    public Camera cityCamera;

    public GameObject battleUi;

    public GameObject positionGameObject;
    public Transform positionPos;



    void Start()
    {
        battleCamera.enabled = false;
    }


    public void SetupBattle()
    {

        //Get PlayerManagerCombat et on l'active
        player.transform.GetChild(1).gameObject.SetActive(true);
        //Get PlayerManagerCity et on le désactive
        player.transform.GetChild(0).gameObject.SetActive(false);

        //switch camera
        battleCamera.enabled = true;
        cityCamera.enabled = false;

        //on instancie le ForCombat
        var position = Instantiate(positionGameObject, positionPos.position , Quaternion.identity);
        //on replace les ennemis sur les pos
        player.transform.GetChild(1).gameObject.GetComponent<Scr_MovePositions>().SetPos(position.GetComponent<Scr_PositionsManager>().playerPositions);
        enemy[0].GetComponent<Scr_MovePositions>().SetPos(position.GetComponent<Scr_PositionsManager>().ennemiPositions);
        //Active l'Ui
        battleUi.SetActive(true);
        //Desactive l'encounter
        var collide = transform.parent.gameObject.GetComponent<SphereCollider>();
        collide.enabled = false;

        Debug.Log("Battle Start");
        state = BattleState.PLAYERTURN;

    }

    public void EnnemyTurn()
    {
        enemy[0].GetComponent<Scr_Ennemi>().Turn();
        enemy[0].GetComponent<Scr_TakeDamages>().Turn();
    }

    public void PlayerTurn()
    {
        player.transform.GetChild(1).GetComponent<Scr_ClickOnObjectInScne>().Turn();
        player.transform.GetChild(1).GetComponent<Scr_TakeDamages>().Turn();
    }

    public void PlayerEndTurn()
    {
        state = BattleState.ENEMYTURN;
        Debug.LogWarning("Player end turn");
        player.transform.GetChild(1).GetComponent<Scr_ClickOnObjectInScne>().playerInput.DeactivateInput();
        EnnemyTurn();
    }

    public void EnemyEndTurn()
    {
        state = BattleState.PLAYERTURN;
        Debug.Log("Ennemi end turn");
        player.transform.GetChild(1).GetComponent<Scr_ClickOnObjectInScne>().playerInput.ActivateInput();
        PlayerTurn();

    }

}
