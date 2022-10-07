using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUiScript : MonoBehaviour
{
    private TMP_Text whichPlayerText;
    

    // Start is called before the first frame update
    void Start()
    {

        whichPlayerText = GetComponent<TMP_Text>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (TurnOrder.PlayerAnimationDone())
        {

            whichPlayerText.text = TurnOrder.CurrentPlayerName();

        }
        else
        {
            whichPlayerText.text = "";


        }


    }
}
