using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class NavMeshPlayer : MonoBehaviour
{

    private NavMeshAgent agent;

    private LineRenderer lr;
    [SerializeField] private Vector3 positionToTravell;

    private bool moveTime;
    private GameObject MyChild;

    [SerializeField] private float distance;
    private Vector2 positiontoTravellVector;
    private Vector2 playerVector;

    private float timer;
    [SerializeField] private float maxTimer = 10;



    private Vector3 whereToTravel;



    private GameObject whereIDig;
    private bool ImGoingToDIg;


    void Start()
    {
        timer = maxTimer;
        agent = GetComponent<NavMeshAgent>();

        lr = gameObject.GetComponent<LineRenderer>();
        positionToTravell = transform.position;
        whereToTravel = transform.position;


    }


    void Update()
    {

        
        if (moveTime)
        {

            agent.SetDestination(positionToTravell);
            lineController(positionToTravell);



            timer -= Time.deltaTime;
        }



        distance = Vector3.Distance(transform.position, new Vector3(positionToTravell.x, transform.position.y, transform.position.z));


         positiontoTravellVector = new Vector2(positionToTravell.x, positionToTravell.z);

         playerVector = new Vector2(transform.position.x, transform.position.z);

        if (ImAtLocation())
        {


            moveTime = false;


        }


    }




    public void lineController(Vector3 endpos)
    {
        if (!moveTime)
        {
            lr.enabled = true;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, endpos);

        }

    }
    public Vector3 MovePosition(Vector3 endpos)
    {

        whereToTravel = endpos;


        return positionToTravell;
    }


    public void DestoryChild()
    {
        Transform[] ts = GetComponentsInChildren<Transform>();
        foreach(Transform t in ts)
        {
            if(t.tag == "Destroyable")
            {

                MyChild = t.gameObject;
                Object.Destroy(MyChild);



            }

        }

    }

    public void Move()
    {
        timer = maxTimer;

        positionToTravell = whereToTravel;

        moveTime = true;

   

        DestoryChild();


        if (ImGoingToDIg)
        {
            whereIDig.GetComponent<HoleTeleport>().AddToList(gameObject);


        }


    }

    public void PositionChange(Vector3 ChangeMovementPlace)
    {

        positionToTravell = ChangeMovementPlace;


    }



    public int ImDone()
    {
       
        if (ImAtLocation())
        {


            return 1;


        }
        else return 0;


       
    }

    public bool ImAtLocation()
    {

      


      return  playerVector == positiontoTravellVector;



        

    }

    public void DoITravelThroughHole(GameObject digLocation)
    {
        whereIDig = digLocation;
        ImGoingToDIg = true;

    }





}
