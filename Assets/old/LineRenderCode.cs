using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class LineRenderCode : MonoBehaviour
{


    [SerializeField] private LineRenderer lr;


    private GameObject projectilePrefab;
    private int stepCount = 10;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position + transform.forward * 50f;

        lr.SetPosition(0, start);
        lr.SetPosition(1, end);


    }

    public void DrawCurvedTrajectory(Vector3 force)
    {

        //float projectileMass = pro



    }

}
