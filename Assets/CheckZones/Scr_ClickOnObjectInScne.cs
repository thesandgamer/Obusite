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
    private Scr_Player playerManager;
    public Scr_CapaDataBase dataBase;

    private int actionsMax = 2;
    private int actionsRestantes;

    [HideInInspector] public Scr_AttackCapa actualCapa;
    [HideInInspector] public Scr_AutoCapa actualAutoCapa;



    private void Start()
    {
        actionsRestantes = actionsMax;
        currentControlScheme = playerInput.currentControlScheme;
        attaqueManager = GetComponent<Scr_Attaque>();
        capaciteManager = GetComponent<Scr_Capa>();
        posManager = GetComponent<Scr_MovePositions>();
        playerManager = GetComponent<Scr_Player>();
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

        int capaCentaines = capacite / 100;
        int capaDizaines = (capacite - (capaCentaines * 100)) / 10;
        int capaUnites = capacite - (capaCentaines * 100) - (capaDizaines * 10);
        
        /*
        Debug.Log("Centaines : " + capaCentaines);
        Debug.Log("Dizaines : " + capaDizaines);
        Debug.Log("Unité : " + capaUnites);
        */

        switch (capaCentaines)
        {
            case 0:
                    actualCapa = dataBase.AttackCapa[capaciteManager.capacite[capaDizaines].intCapa].attackCapa[capaUnites];
                    actualAutoCapa = null ;
                    Debug.Log("Capacité actuelle:  " + actualCapa.name);
                break;

            case 1:
                //Erreur: il lit le int capa de la capacité 0, du coup il faut bien séparer les attack capa des auto capa
                    actualAutoCapa = dataBase.AutoCapa[capaciteManager.autoCapacite[capaDizaines].intCapa].autoCapa[capaUnites];
                    actualCapa = null;
                    Debug.Log("Capacité auto actuelle:  " + actualAutoCapa.name);
                break;
                
                

            default:
                break;

        }
        
        
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
                    Debug.Log("Ennemi");
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
 
                if (hitObject.CompareTag("Ennemi") && actualCapa != null)
                {
                    //Check si le perso est à la bonne place pour faire son attaque
                    bool porteeValide = false;
                    for (int i = 0; i < 4; i++)
                    {
                        if (posManager.actualPosition == posManager.pos[i])
                        {
                            if (actualCapa.portee[i] == true)
                            {
                                porteeValide = true;
                            }
                        }
                    }

                    bool moralValide = false;
                    if (playerManager.moral >= actualCapa.moralRequire)
                    {
                        moralValide = true;
                    }

                    Debug.Log("La portées est valide? " + porteeValide);
                    Debug.Log("Le moral est valide? " + moralValide);
                    
                    if (porteeValide && moralValide)
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

                if (hitObject.CompareTag("Player") && actualAutoCapa != null)
                {

                    bool moralValide = false;
                    if (playerManager.moral >= actualAutoCapa.moralRequire)
                    {
                        moralValide = true;
                    }


                    if (moralValide)
                    {
                        attaqueManager.CalculateIfTouch(hitObject.gameObject, actualAutoCapa);
                        Debug.Log("Je me suis mis: " + actualAutoCapa);
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
