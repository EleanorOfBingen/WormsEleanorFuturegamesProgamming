using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int health = 3;
    [SerializeField] HealthBarScript healthBarScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IlooseHealth(int healthloss)
    {

        health -= healthloss;
        if(health <= 0)
        {

            Death();

        }
        healthBarScript.SetHealth(health);


    }
    public void Death()
    {

        Destroy(gameObject);

    }





}
