using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastHitWall : MonoBehaviour
{

    [SerializeField] LayerMask mask;
    [SerializeField] float distance = 50f;
    RaycastHit hit2;
    Vector3 playerPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        playerPoint = Camera.main.WorldToScreenPoint(transform.position);


    }

    public void IhitWall(Vector3 currentWurm)
    {


        if (Physics.Raycast(currentWurm, Input.mousePosition - currentWurm, out hit2, distance))
        {
            Debug.Log(hit2.collider.tag);


        }




    }


}
