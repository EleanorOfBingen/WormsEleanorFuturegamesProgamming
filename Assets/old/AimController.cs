using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{

    [SerializeField] private GameObject aimer;
    [SerializeField] private GameObject pointOFMovement;
    //[SerializeField] private bool created;
    [SerializeField] private GameObject moveAimer;
    [SerializeField] private LayerMask mask;


    [SerializeField] private bool hitPlayer;
    [SerializeField] private GameObject currentWorm;

    private NavMeshPlayer nmp;

    // Start is called before the first frame update
    void Start()
    {

        moveAimer = Instantiate(aimer);
        moveAimer.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 hitvector = new Vector3(hit.point.x, transform.position.y, hit.point.z);



        //if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100.0f))
        //{

        //}

        if (Physics.Raycast(ray, out hit, 100.0f))
        {

            if (hit.collider.tag == "Player" && Input.GetMouseButtonDown(0))
            {

                Debug.Log("FuckIHittThePlayer");

                hitPlayer = true;
                currentWorm = hit.collider.gameObject;
                nmp = currentWorm.GetComponent<NavMeshPlayer>();

            }

            if (hitPlayer)
            {

                SetActiveAimer(hit);
                nmp.lineController(hit.point);
            }
            else
            {



            }



            // Debug.Log("fuck2");


            // aimer.transform.position = hit.point;



        }


        if (Input.GetMouseButtonUp(0) && hitPlayer)
        {
            moveAimer.SetActive(false);
            hitPlayer = false;
            /// moveAimer = null;
            /// 
            Debug.Log("fuck1");
            InstantatePointOfMovement(hit.point);
            nmp.MovePosition(hit.point);
            //nmp.IsItTimeToMove(1);

        }



    }

    public void SetActiveAimer(RaycastHit ray)
    {

        moveAimer.SetActive(true);
        moveAimer.transform.position = ray.point;

    }


    public bool raycastHiting(RaycastHit ray)
    {


        return ray.collider != null;
    }

    void InstantatePointOfMovement(Vector3 positionInstantiate)
    {


        Instantiate(pointOFMovement, new Vector3(positionInstantiate.x, positionInstantiate.y, positionInstantiate.z), transform.rotation);

    }


}
