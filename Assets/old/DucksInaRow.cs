using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DucksInaRow : MonoBehaviour
{

    [SerializeField]private int pos;
    private Duck[] ducks;
    [SerializeField] Duck newDuck;
    // Start is called before the first frame update
    void Start()
    {

        ducks = GetComponentsInChildren<Duck>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && pos > ducks.Length)
        {

            ducks[pos].RandomColour();


        }
        if (Input.GetKeyUp(KeyCode.X))
        {

            ducks[ducks.Length + 1] = newDuck;

        }



    }
}
