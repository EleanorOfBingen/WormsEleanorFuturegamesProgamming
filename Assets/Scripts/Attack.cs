using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private bool attack;
    private bool readyToAttack;
    private GameObject dwarfToAttack;
    private bool doneWithAttack;


    private float timerAttack;
    private float timerAttackMax = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;





        if (attack && dwarfToAttack != null)
        {
            if (Physics.Raycast(transform.position, dwarfToAttack.transform.position - transform.position, out hit, 1.5f))
            {
                if (hit.collider.gameObject == dwarfToAttack)
                {

                    dwarfToAttack.GetComponent<Health>().IlooseHealth(1);
                    GetComponent<NavMeshPlayer>().PositionChange(transform.position);

                    readyToAttack = false;         
                    
                    attack = false;
                }

            }

        }
        else
        {

            doneWithAttack = true;

        }

        if (doneWithAttack)
        {

            timerAttack -= Time.deltaTime;

        }





    }
    public void WhoiAttack(GameObject whom)
    {

        doneWithAttack = false;
        dwarfToAttack = whom;
        readyToAttack = true;
        //positionToTravell = whom.transform.position;
        GetComponent<NavMeshPlayer>().MovePosition(whom.transform.position);
        // return attackedThingy;
    }

    public void AttackTheCreature()
    {
        timerAttack -= timerAttackMax;
        attack = true;
        GetComponent<NavMeshPlayer>().MovePosition(dwarfToAttack.transform.position);
        GetComponent<NavMeshPlayer>().Move();
    }

    public int DoneAttacking()
    {

        if (timerAttack <= 0)
        {

            return 1;

        }else

        return 0;
    }

}
