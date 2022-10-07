using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class WhatIDo : MonoBehaviour
{

    [SerializeField] private string action;

    private Shooter shooter;
    private NavMeshPlayer nmp;
    private Attack attack;
    private Dig diggin;

    [SerializeField] private string WhatTypeAmAI;

    [SerializeField] private String[] whatICanDo;
    private int whatID;

    [SerializeField] private TMP_Text typeString;
    [SerializeField] private TMP_Text ammoString;

    [SerializeField] private int playerAmI;

    [SerializeField] private Material[] materialPlayer;

    [SerializeField] private Button bt;

    private void Awake()
    {

        WhatPlayerDoIBelongTo(playerAmI);

    }

    private void Start()
    {

        whatICanDo = new String[]{"Cannon","Axe" };

        ChangeType(0);
        shooter = GetComponent<Shooter>();
        nmp = GetComponent<NavMeshPlayer>();
        attack = GetComponent<Attack>();
        diggin = GetComponent<Dig>();

    }


    public string WhatActionDoIDo(string actionString)
    {

        return action = actionString;

    }

    public void InstantiateAction()
    {
        //Move
        if (action == TurnOrder.Action1())
        {

            nmp.Move();

        }

        //Shoot
        if(action == TurnOrder.Action2())
        {

            if (WhatTypeAmAI == "Cannon")
            {
                shooter.Shoot();
            }
            else
            {
                GetComponent<Attack>().AttackTheCreature(); ;


            }


        }
        if(action == TurnOrder.Action3())
        {
            diggin.MoveTowardsDiggin();


        }
        ChangeType(0);

    }

    public int Done()
    {
        if(action == TurnOrder.Action1())
        {

            return nmp.ImDone();

        }
        if (action == TurnOrder.Action2())
        {
            if (WhatTypeAmAI == "Cannon")
            {
                return shooter.ShotsDone();
            }
            else
            {
                return attack.DoneAttacking();


            }
        

        }

        if (action == TurnOrder.Action3())
        {

            return GetComponent<Dig>().DiggingDone();

        }
        return 0;



    }
    public string WhatAmI()
    {


        return WhatTypeAmAI;
    }

    public void ChangeType(int changnmbr)
    {

        whatID += changnmbr;
        whatID = Mathf.Clamp(whatID, 0, (whatICanDo.Length - 1));

        WhatTypeAmAI = whatICanDo[whatID];
        typeString.text = WhatTypeAmAI;
        if(WhatTypeAmAI == whatICanDo[0])
        {
            if (shooter != null)
            {

                ammoString.text = "Ammo: " + shooter.HowMuchAmmo();
            }

        }
        else
        {

            ammoString.text = "";

        }
    }
    public void WhatPlayerDoIBelongTo(int playerNumber)
    {
        gameObject.tag = "Player" + playerNumber.ToString();
        gameObject.GetComponent<MeshRenderer>().material = materialPlayer[playerNumber]; 




    }
    public Button ThisButton()
    {


        return bt;

    }









}
