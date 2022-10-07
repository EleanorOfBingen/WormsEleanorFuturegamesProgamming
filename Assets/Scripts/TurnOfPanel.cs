using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnOfPanel : MonoBehaviour
{


    private Image image;

    // Start is called before the first frame update
    void Start()
    {

        image = GetComponent<Image>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TurnOrder.PlayerAnimationDone())
        {

            image.enabled = true;

        }
        else
        {
            image.enabled = false;


        }

        
    }
}
