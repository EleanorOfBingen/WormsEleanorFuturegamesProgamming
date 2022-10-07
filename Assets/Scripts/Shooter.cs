using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] private GameObject target;

    private int bulletAmount = 2;
    private int bulletpain = 1;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject childBullet;
 

    private bool shotsFired;


    private float timerShooting;
    private float timerShootingMax = 10f;
    private bool activateShootTimer;

    private void Start()
    {
        timerShootingMax = 10f;
    }


    public void Update()
    {

        if (activateShootTimer)
        {

            timerShooting -= timerShootingMax;

        }
        if(timerShooting <= 0)
        {

            shotsFired = false;

        }



    }

    public void Shoot()
    {
        timerShooting = timerShootingMax;
        activateShootTimer = true;
        childBullet = Instantiate(bullet, transform.position, transform.rotation, transform);

        childBullet.GetComponent<BulletShot>().Target(target, gameObject);

        shotsFired = true;

        bulletAmount--;
        
    }

    public GameObject WhoAmIShooting(GameObject whomstIShoot)
    {

        activateShootTimer = false;
        return target = whomstIShoot; 
    }
    public void Hit()
    {

      
        
        target.GetComponent<Health>().IlooseHealth(bulletpain);
        Destroy(childBullet);

    }
    public void DidNotHit()
    {

        activateShootTimer = true;

    }


    public int ShotsDone()
    {
        if(timerShooting <= 0)
        {


            return 1;

        }
        else
        {

            return 0;
        }


    }
    public bool AmIOutOfAmmo()
    {

        return bulletAmount < 1;
        
    }

    public int HowMuchAmmo()
    {

        return bulletAmount;

    }


}
