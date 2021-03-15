using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum Mode {Aucun,Move,Capa }

public class Scr_ClickOnObjectInScne : MonoBehaviour
{

    public Mode mode;

    [SerializeField] private LayerMask collisionMask;

    [Header("RayCast")]
    [Range(0, 100)]
    public float rayLength = 100;

    [Header("Input Settings")]
    public PlayerInput playerInput;
    private string currentControlScheme;

    RaycastHit hit;

    GameObject hitObject;

    public Scr_TurnManager turnManager;
    private Scr_MovePositions posManager;
    private Scr_Attaque attaqueManager;
    private Scr_Capa capaciteManager;
    public Scr_CapaDataBase dataBase;

    private int actionsMax = 2;
    private int actionsRestantes;

    [HideInInspector] public Scr_AttackCapa actualCapa;
    


    private void Start()
    {
        actionsRestantes = actionsMax;
        currentControlScheme = playerInput.currentControlScheme;
        attaqueManager = GetComponent<Scr_Attaque>();
        capaciteManager = GetComponent<Scr_Capa>();
        posManager = GetComponent<Scr_MovePositions>();
        mode = Mode.Aucun;
    }

    void Update()
    {
        ScreenRayCast();
    }


    void ScreenRayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayLength, collisionMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
            Debug.DrawRay(hit.point, ray.direction * rayLength, Color.green);
            hitObject = hit.collider.gameObject;
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
            hitObject = null;
        }

    }



    public void OnClick(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if (hitObject != null)
            {
                Activation();
            }
        }

    }



    public void AttackMode(int capacite)
    {
        mode = Mode.Capa;
        //actualCapa = capaciteManager.attackCapa[capacite];
        //actualCapa = dataBase.capa[capacite].attackCapa[capacite;
        //Debug.Log(capaciteManager.capacite[capacite].intCapa);

        //actualCapa = dataBase.capa[capaciteManager.capacite[capacite].intCapa];
        int capaDizaines = capacite / 10;
        int capaUnites = capacite - capaDizaines * 10;
        Debug.Log(capaDizaines);
        Debug.Log(capaUnites);

        actualCapa = dataBase.capa[capaciteManager.capacite[capaDizaines].intCapa].attackCapa[capaUnites];

        //Debug.Log(capacite);
        Debug.Log(actualCapa.name);
        Activation();

    }


    public void Activation()
    {
        switch (mode)
        {
            case Mode.Aucun:
                if (hitObject.CompareTag("Player"))
                {
                    Debug.Log("cliqué sur soi");
                    mode = Mode.Move;
                }
                if (hitObject.CompareTag("Ennemi"))
                {
                    //Debug.Log("Ennemi");
                    
                }
                break;

            case Mode.Move:
                if (hitObject.GetComponent<Scr_Pos>() != null) //Quand on clique sur une zone de position
                {
                    if (posManager.actualPosition != hitObject.transform)
                    {
                        Transform hitpos = hitObject.GetComponent<Scr_Pos>().Cliqued();
                        posManager.MoveToPosition(hitpos);
                        ActionFaite();
                        mode = Mode.Aucun;
                    }
                }
                break;

            case Mode.Capa:
                if (hitObject == null)
                    break;
 
                if (hitObject.CompareTag("Ennemi"))
                {
                    //Check si le perso est à la bonne place pour faire son attaque
                    bool valide = false;
                    for (int i = 0; i < 4; i++)
                    {
                        if (posManager.actualPosition == posManager.pos[i])
                        {
                            if (actualCapa.portee[i] == true)
                            {
                                valide = true;
                            }
                        }
                    }

                    Debug.Log(valide);
                    
                    if (valide)
                    {
                        Debug.Log(hitObject.name);
                        var ennemi = hitObject.transform.parent.GetComponent<Scr_Ennemi>();

                        attaqueManager.CalculateIfMakeDamages(hitObject.transform.parent.gameObject, actualCapa, posManager.actualPosition, hitObject.name); //Stoquer la partie touchée
                        ActionFaite();
                        mode = Mode.Aucun;

                    }
                    else
                    {
                        //Grise le bouton est on emèche d'appuyer dessus
                        mode = Mode.Aucun;
                    }
                }
                break;

            default:
                break;

        }
    }



    public void ActionFaite()
    {
        if(actionsRestantes >1)
        {
            actionsRestantes--;
        }
        else
        {
            turnManager.PlayerEndTurn();
        }
        
    }

    public void Turn()
    {
        actionsRestantes = actionsMax;
    }



    bool CheckIfPorteeCapaIsValid()
    {
        if(actualCapa.portee[0] == posManager.actualPosition)
        {
            return true;
        }
        else
        {
            return false;
        }

    }





}
