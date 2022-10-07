using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshNavigator : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<Vector3> movementList;
   // [SerializeField] private List<Vector2> movementList2;
    [SerializeField] private int movementListNumber;
    [SerializeField] private GameObject aimer;
    bool activate;

    [SerializeField] private int maxClicks;
    [SerializeField] private int clicks;


    // Start is called before the first frame update
    void Start()
    {
        movementListNumber = 0;
        //movementList.Add(transform.position);
        aimer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 hitvector = new Vector3(hit.point.x, transform.position.y, hit.point.z);

        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit, 100.0f) && MaxAmountClicks())
        {
            aimer.SetActive(true);
            aimer.transform.position = hit.point;

        }
        else
        {

            aimer.SetActive(false);

        }




        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("fuck1");



           
            if (Physics.Raycast(ray, out hit, 100.0f) && MaxAmountClicks())
            {
              //  Debug.Log("fuck2");

                // movementList.Add(hit.point);
                //  agent.SetDestination(hit.point);
                clicks += 1;


            }

        }


        if (Input.GetKeyUp(KeyCode.Space))
        {

            //make this into an button.

            activate = true;

            //movementListNumber += 1;



        }

        if (activate)
        {
            agent.SetDestination(movementList[movementListNumber]);
        }
        
        
        if(AminextToLocation(transform.position, movementList[movementListNumber]) && activate == true)
        {

            movementListNumber += 1;

            
        
        
        }
        if (movementListNumber == clicks && activate)
        {

            //Debug.Log()
            activate = false;
            movementList = new List<Vector3>();
            movementListNumber = 0;
            clicks = 0;
            

        }


           // agent.SetDestination(movementList[movementListNumber]);




    }


    public bool MaxAmountClicks()
    {

        return clicks < maxClicks;
    }



    public bool AminextToLocation(Vector3 wormpos, Vector3 aimposs)
    {
        //float distance = Vector3.Distance(wormpos, aimposs);

        return wormpos == new Vector3 (aimposs.x, wormpos.y, aimposs.z);
        

    }


    
}
