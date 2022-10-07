using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomColour()
    {
        Color colour = new Color(Random.Range(0, 1f), Random.Range(0, 1f), 1f);


    }


}
