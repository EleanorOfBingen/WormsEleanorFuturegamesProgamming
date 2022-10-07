using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHolder : MonoBehaviour
{
    static StatHolder instance;

    public static float moveDistance = 10;
    public static float attackDistance = 10;
    public static float shootDistance = 100;
    // private List<float> move;


    private string Attaker = "Attaker";
    private string Canon = "Canon";







    private void Awake()
    {

        if (instance == null)
        {

            instance = this;

        }

        //player1 = GameObject.FindGameObjectsWithTag(CurrentPlayerName());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static StatHolder GetInstance()
    {


        return instance;
    }

    public static float Distance(string playerType)
    {



        StatHolder sH = GetInstance();

        if (playerType == sH.Canon)
        {
            return shootDistance;

        }
        if (playerType == sH.Attaker)
        {
            return attackDistance;

        }
        else
        {

            return moveDistance;
        }


   

    }


}
