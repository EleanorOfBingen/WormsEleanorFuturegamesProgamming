using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UiPlayerHasWon : MonoBehaviour
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

        if (TurnOrder.PlayerWon())
        {
            text.text = "You have Won!";
            text.text = "G:" + GameObject.FindGameObjectsWithTag("Player0").Length + "  Y:" + GameObject.FindGameObjectsWithTag("Player1").Length + "  B:" + GameObject.FindGameObjectsWithTag("Player2").Length + "  R:" + GameObject.FindGameObjectsWithTag("Player3").Length;


        }
        else
        {
            text.text = "G:" + GameObject.FindGameObjectsWithTag("Player0").Length + "  Y:" + GameObject.FindGameObjectsWithTag("Player1").Length + "  B:" + GameObject.FindGameObjectsWithTag("Player2").Length + "  R:" + GameObject.FindGameObjectsWithTag("Player3").Length;


        }


    }
}
