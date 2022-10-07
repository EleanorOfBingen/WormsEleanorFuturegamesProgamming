using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 mouseMove = Camera.main.WorldToScreenPoint(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            {



             transform.position = hit.point;


            }
    }
}
