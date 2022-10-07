using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendCon : MonoBehaviour
{

    private Vector3 startpoint;
    private Vector3 endpoint;
    private LineRenderer lr;

    [SerializeField] private Material inRangeMaterial;
    [SerializeField] private Material outRangeMaterial;


    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>(); 

    }

    // Update is called once per frame
    void Update()
    {


        
    }

    public void LineRenderPositions(Vector3 startpoint, Vector3 endpoint, bool InRange)
    {
        lr.SetPosition(0, startpoint);
        lr.SetPosition(1, endpoint);

        if (!InRange)
        {
            lr.material = inRangeMaterial;


        }
        else
        {
            lr.material = outRangeMaterial;


        }
        



    }

    



    void HilightPlayer()
    {



    }


}
