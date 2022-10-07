using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;


public class Dig : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]private Vector3 digEntrence;
    [SerializeField] private Vector3 digExit;

    private bool moveToDig;
    private bool digginDone;

    private NavMeshAgent nma;
    private NavMeshPlayer nmPlayer;

    private bool amther;
    Vector2 playerVector;
    Vector2 positiontoTravellVector;

    private float digginTimer;
    private float maxDiggingTimer = 0.5f;

    [SerializeField] private GameObject hole;

    private float[] directionMovement;

    [SerializeField] private GameObject button;
    
    

    void Start()
    {

        directionMovement = new float[]{-1.5f,-1,1,1.5f};
       

        nma = GetComponent<NavMeshAgent>();
        nmPlayer = GetComponent<NavMeshPlayer>();


    }

    void Update()
    {



        if (moveToDig)
        {
            Destroy(button);
            nma.Warp(digExit);
            nmPlayer.MovePosition(digExit);
            CreateDigginHoles();
            digginDone = true;
            moveToDig = false;
        }

        if (digginDone)
        {

            nmPlayer.MovePosition(digExit + new Vector3(directionMovement[Random.Range(0,directionMovement.Length)],0, directionMovement[Random.Range(0, directionMovement.Length)]));
            nmPlayer.Move();
            digginTimer -= Time.deltaTime;

        }

        if (digginTimer <= 0)
        {

            digginDone = false;

        }

    }

    public void SetEntrence(Vector3 entrence)
    {


        digEntrence = entrence;

    }

    public void SetExit(Vector3 exit)
    {

        digExit = exit;

    }

    public void MoveTowardsDiggin()
    {
        digginTimer = maxDiggingTimer;
        nmPlayer.MovePosition(digEntrence);
        nmPlayer.Move();
        moveToDig = true;

    }

    public int DiggingDone()
    {
        if(moveToDig == false && digginDone == false)
        {

            return 1;

        }
        return 0;

    }
    
    public void CreateDigginHoles()
    {
        GameObject firstObject = Instantiate(hole, digEntrence, transform.rotation);
        firstObject.GetComponent<HoleTeleport>().DigExitPoint(digExit);

        GameObject secondObject = Instantiate(hole, digExit, transform.rotation);
        secondObject.GetComponent<HoleTeleport>().DigExitPoint(digEntrence);
    }

}
