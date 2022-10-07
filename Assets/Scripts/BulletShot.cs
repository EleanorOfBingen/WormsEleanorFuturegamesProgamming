using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletShot : MonoBehaviour
{

    private GameObject whereItravel;
    [SerializeField]private bool killMe;
    private GameObject whoFiredMe;

    
    private float bullletTimer = 7f;

    private Shooter father;



    void Start()
    {

       // gameObject.tag = transform.parent.tag;
        father = whoFiredMe.GetComponentInParent<Shooter>();

    }


    void Update()
    {
        if (whereItravel == null)
        {

            father.DidNotHit();
            Destroy(transform.gameObject);

        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, whereItravel.transform.position, 10f * Time.deltaTime);

        }
       

        bullletTimer -= Time.deltaTime;
        
       
        Destroy(transform.gameObject, 10f);

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag != father.tag)
        {


            father.Hit();
            Destroy(transform.gameObject);


        }
      




    }

    public void  Target(GameObject target, GameObject firerer)
    {


        whereItravel = target;
        whoFiredMe = firerer;
    }


}
