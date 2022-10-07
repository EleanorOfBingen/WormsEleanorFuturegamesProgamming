using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnOfText : MonoBehaviour
{

    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
        text = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!TurnOrder.PlayerAnimationDone())
        {

            text.enabled = false;

        }
        else
        {
            text.enabled = true;


        }

    }
}
