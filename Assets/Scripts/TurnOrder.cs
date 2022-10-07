using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TurnOrder : MonoBehaviour
{
    static TurnOrder instance; 
    [SerializeField]private GameObject[] playerUnits;
    [SerializeField]private GameObject[] nextPlayerUnits;


    private string playerName;
    private int currentPlayer;


    [SerializeField] int currentAmountOfPlayers = 3;
    private int defeatedPlayer;
    private int restartCurrentPlayer;
    private ControllerNavMesh conNavMesh;
    private int unitsAmount;
    private int unitsPlayed;

    [SerializeField] string action1 = "Move";
    [SerializeField] string action2 = "Attack";
    [SerializeField] string action3 = "Dig";
    [SerializeField] string action4;


    private float timer;
    [SerializeField] float timerMax = 5f;
    private float timerFinish;
    [SerializeField] float timerMaxForRound = 15f;




    private bool endTurn;

    [SerializeField] private CameraController cc;
    private void Awake()
    {
        
        if(instance == null)
        {

            instance = this;

        }

    
    }



    void Start()
    {

        
        conNavMesh = GetComponent<ControllerNavMesh>();

        currentPlayer = 0;



        timer = timerMax;
        conNavMesh.RestartFocus();

        restartCurrentPlayer = 1;

    }

    void Update()
    {

        if (PlayerAnimationDone())
        {

            if (Input.GetKeyUp(KeyCode.Space))
            {
                endTurn = true;
                timerFinish = timerMaxForRound;
                
            }


        }
        else
        {

            timerFinish -= Time.deltaTime;
        }
        
        if (endTurn)
        {

            timer -= Time.deltaTime;
        }
        else
        {

            timer = timerMax;
            
        }


        if(timer < 0 && endTurn)
        {

            FindAllWorms();
           
        }

         unitsPlayed = UnitCount(0);

    }

    public static TurnOrder GetInstance()
    {


        return instance;
    }


    void FindAllWorms()
    {

        unitsAmount = 0;
        playerUnits = GameObject.FindGameObjectsWithTag(CurrentPlayerName());

        foreach ( GameObject worm in playerUnits)
        {
            unitsAmount += 1;
            worm.GetComponent<WhatIDo>().InstantiateAction();
            worm.GetComponent<WhatIDo>().WhatActionDoIDo(action1);
          
        }

        currentPlayer += 1;

        currentPlayer %= currentAmountOfPlayers;
        nextPlayerUnits = GameObject.FindGameObjectsWithTag(CurrentPlayerName());

       
        if(nextPlayerUnits.Length <= 0)
        {
            

            defeatedPlayer += 1;
            if(PlayerWon())
            {
                Debug.Log("IHAVEWON");
             
            }
            else
            {

                FindAllWorms();


            }
         

        }
        else
        {
            restartCurrentPlayer = 1;
            defeatedPlayer = 0;
            conNavMesh.RestartFocus();

            endTurn = false;


        }



    }


    public static string CurrentPlayerName()
    {
         
        TurnOrder tO = GetInstance();
        return "Player" + tO.currentPlayer;
        
    }

    public static bool PlayerAnimationDone()
    {
        
        TurnOrder tO = GetInstance();
        if(tO.timerFinish < 0)
        {

            return true;

        }
        
        return tO.unitsAmount == tO.unitsPlayed && tO.endTurn == false;

    }

    public int UnitCount(int unitDone)
    {
       
       foreach (GameObject unit in playerUnits)
        {
            WhatIDo unitWhatIDo = unit.GetComponent<WhatIDo>();
            if (unitWhatIDo != null)
            {

                unitDone += unit.GetComponent<WhatIDo>().Done();

            }
          
        }

        return unitDone;
    }

    public static string Action1()
    {

        TurnOrder tO = GetInstance();
        return tO.action1;

    }
    public static string Action2()
    {

        TurnOrder tO = GetInstance();
        return tO.action2;

    }
    public static string Action3()
    {

        TurnOrder tO = GetInstance();
        return tO.action3;

    }


    public static GameObject FocusedUnit(int unitNmr)
    {
        TurnOrder tO = GetInstance();
        return tO.playerUnits[unitNmr];


    }
    public static int AmountWormsCurrentPlayers()
    {
        TurnOrder tO = GetInstance();
        return tO.playerUnits.Length;


    }
    public static bool PlayerWon()
    {
        TurnOrder tO = GetInstance();
        return tO.defeatedPlayer == (tO.currentAmountOfPlayers - 1);

    }





}
