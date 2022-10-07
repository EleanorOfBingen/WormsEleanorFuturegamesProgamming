using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ControllerNavMesh : MonoBehaviour
{

    [SerializeField] private GameObject aimer;
    [SerializeField] private GameObject pointOFMovement;
    [SerializeField] private LayerMask mask;


    private bool hitPlayer;
    private GameObject currentUnit;
 
    private NavMeshPlayer nmp;
    private Attack attack;

    private bool iShoot;

    [SerializeField] GameObject[] unitsOfType;

    [SerializeField] private WhatIDo wid;
    private LineRendCon lrc;


    [SerializeField]private float distance;
    private float maxDistance = 10;
    private float shootDistance = 50;


   
    [SerializeField] float distance2 = 50f;
    private RaycastHit hit2;
    private Vector3 playerPoint;


    [SerializeField]private GameObject coursor;

    private bool pressedDown;
    private RaycastHit hit;

    private bool ihitwall;

    private bool dig;
    private bool digLocationPlaced;
    private Vector3 digLocation;
    private bool imGoingToEnterDigHole;
    [SerializeField] private GameObject digHole;
    private HoleTeleport ht;

    private Dig digger;


    private GameObject[] currentAmountWurms;

    [SerializeField] private CameraController cc;

    private int wurmInt;

    private int whatIAmInt;

    private bool iHaveDug;

    [SerializeField] private Button buttonToDig;

    void Start()
    {


        lrc = GetComponent<LineRendCon>();

       

    }

    // Update is called once per frame
    void Update()
    {
        wurmInt = Mathf.Clamp(wurmInt, 0, (currentAmountWurms.Length - 1));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 hitvector = coursor.transform.position;


        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            wurmInt -= 1;
            Focus(currentAmountWurms[wurmInt]);

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            wurmInt += 1;
            Focus(currentAmountWurms[wurmInt]);


        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {

            wid.ChangeType(1);
            nmp.DestoryChild();
            InstantatePointOfMovement(currentUnit.transform.position);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {

            wid.ChangeType(-1);
            nmp.DestoryChild();
            InstantatePointOfMovement(currentUnit.transform.position);

        }

        


        if (currentUnit == null)
        {


        }
        else if(pressedDown)
        {

            //Debug.Log("Cokc");

            lrc.LineRenderPositions(currentUnit.transform.position, hitvector, AmIOutOfRange("", ihitwall));


        }else if (dig)
        {

            lrc.LineRenderPositions(currentUnit.transform.position, hitvector, AmIOutOfRange("", ihitwall));

        }
        else
        {


        }




        if (Physics.Raycast(ray, out hit ,100.0f) && TurnOrder.PlayerAnimationDone())
        {


            if(hit.collider.tag == TurnOrder.CurrentPlayerName() && Input.GetMouseButtonDown(0))
            {

                PressedWurm(hit.collider.gameObject);
                
            }

            if (dig && Input.GetMouseButtonDown(0))
            {

                if (!AmIOutOfRange("", ihitwall))
                {

                    digLocation = hit.point;
                    InstantiateDigLocation(digLocation);
                    
                    digger.SetExit(digLocation);
                    digger.SetEntrence(currentUnit.transform.position);
                    wid.WhatActionDoIDo(TurnOrder.Action3());
                    TurnOfCollider(false);
                    dig = false;
                }
            }





            if (hitPlayer)
            {
                playerPoint = hit.point;
                distance = Vector3.Distance(currentUnit.transform.position, hit.point);
                if (hit.collider.tag == "Hole")
                {
                    imGoingToEnterDigHole = true;
                    lrc.LineRenderPositions(currentUnit.transform.position, hit.collider.gameObject.transform.position, AmIOutOfRange("", ihitwall));

                }
                else
                {
                    imGoingToEnterDigHole = false;
                }

                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    iShoot = true;
                 
                    if (Physics.Raycast(currentUnit.transform.position, hit.collider.gameObject.transform.position - currentUnit.transform.position, out hit2, distance))
                    {
                        if (hit2.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                        {
                            ihitwall = false;

                        }
                        else
                        {
                           
                            ihitwall = true; 

                        }


                      
                        

                    }
                    lrc.LineRenderPositions(currentUnit.transform.position, hit.collider.gameObject.transform.position, AmIOutOfRange(wid.WhatAmI(), ihitwall));
                }
                else
                {
                   
                    iShoot = false;

                }

            }



            else
            {
                if (!dig)
                {
                    lrc.LineRenderPositions(currentUnit.transform.position, currentUnit.transform.position, AmIOutOfRange("", false));
                }

            }

            if (Input.GetMouseButtonUp(0))
            {
                if (pressedDown)
                {

                    if (iShoot)
                    {
                        if (!AmIOutOfRange(wid.WhatAmI(), ihitwall))
                        {



                            PointOfShot(hit.collider.gameObject, wid.WhatAmI());

                        }

                    }
                    else if (!AmIOutOfRange("", ihitwall))
                    {
                        if (imGoingToEnterDigHole)
                        {
                            digHole = hit.collider.gameObject;
                            Debug.Log("HighTide");
                            nmp.DoITravelThroughHole(digHole);


                        }
                        else if(digHole != null)
                        {


                        }
                        
                        InstantatePointOfMovement(hit.point);

                        pressedDown = false;

                        TurnOfCollider(false);

                    }

                    else
                    {

                        InstantatePointOfMovement(currentUnit.transform.position);



                    }

                }
               

                TurnOfCollider(false);
                hitPlayer = false;
                pressedDown = false;
            }

            }


    }




    public bool raycastHiting(RaycastHit ray)
    {


        return ray.collider != null;
    }

    void InstantatePointOfMovement(Vector3 positionInstantiate)
    {
        Instantiate(pointOFMovement, new Vector3(positionInstantiate.x, positionInstantiate.y , positionInstantiate.z), transform.rotation, currentUnit.transform);
        nmp.MovePosition(positionInstantiate);
        wid.WhatActionDoIDo(TurnOrder.Action1());

    }




    void InstantiateDigLocation(Vector3 positionInstantiate)
    {
        Instantiate(pointOFMovement, new Vector3(positionInstantiate.x, positionInstantiate.y, positionInstantiate.z), transform.rotation, currentUnit.transform);


    }


    void PointOfShot(GameObject targetWorm, string playerType)
    {
        if (playerType == "Cannon")
        {
            currentUnit.GetComponent<Shooter>().WhoAmIShooting(targetWorm);
           
        }
        else
        {
           
            attack.WhoiAttack(targetWorm);
           

        }

        wid.WhatActionDoIDo(TurnOrder.Action2());

    }

    bool AmIOutOfRange(string playerType, bool hittWall)
    {

        if (playerType == "Cannon" && hittWall)
        {

            return true;

        }else if (playerType == "Cannon" && !hittWall)
        {


            return distance > shootDistance || currentUnit.GetComponent<Shooter>().AmIOutOfAmmo();
        }
        else
        {

            return distance > maxDistance;

        }

    }

    private void PressedWurm(GameObject wurmorino)
    {

        hitPlayer = true;
        currentUnit = wurmorino;
        Focus(currentUnit);
        nmp = currentUnit.GetComponent<NavMeshPlayer>();
        nmp.DestoryChild();
        wid = currentUnit.GetComponent<WhatIDo>();
        attack = currentUnit.GetComponent<Attack>();

        pressedDown = true;

        TurnOfCollider(true);

        

    }

    public void ClickToDig(Button digButton)
    {


        currentUnit = digButton.gameObject.transform.parent.parent.gameObject;
        dig = true;
        nmp = currentUnit.GetComponent<NavMeshPlayer>();
        nmp.DestoryChild();
        wid = currentUnit.GetComponent<WhatIDo>();
        digger = currentUnit.GetComponent<Dig>();

        TurnOfCollider(true);

    }

    public void TurnOfCollider(bool turnOff)
    {

        unitsOfType = GameObject.FindGameObjectsWithTag(TurnOrder.CurrentPlayerName());

        if (turnOff)
        {
            foreach (GameObject unitTurnOfCollider in unitsOfType)
            {

                unitTurnOfCollider.GetComponent<BoxCollider>().enabled = false;

            }
        }
        if (!turnOff)
        {
            foreach (GameObject unitTurnOfCollider in unitsOfType)
            {

                unitTurnOfCollider.GetComponent<BoxCollider>().enabled = true;

            }
        }

    }
    public void RestartFocus()
    {

        currentAmountWurms = GameObject.FindGameObjectsWithTag(TurnOrder.CurrentPlayerName());
        wurmInt = 0;
        Focus(currentAmountWurms[0]);

    }

    

    public void Focus(GameObject worm)
    {
        if (buttonToDig == null)
        {
            

        }
        else 
        {
            buttonToDig.image.enabled = false;
            buttonToDig.transform.GetChild(0).gameObject.SetActive(false);


        }




        currentUnit = worm;
        cc.ChangeFocus(currentUnit);

        wid = currentUnit.GetComponent<WhatIDo>();
        buttonToDig = wid.ThisButton();
        if(buttonToDig == null)
        {


        }
        else
        {
            buttonToDig.transform.GetChild(0).gameObject.SetActive(true);
            buttonToDig.image.enabled = true;
            buttonToDig.onClick.AddListener(() => ClickToDig(wid.ThisButton()));


        }
       
        nmp = currentUnit.GetComponent<NavMeshPlayer>();
 
    }














}
