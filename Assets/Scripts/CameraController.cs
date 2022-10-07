using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ground;

    float zoomFloat;

    private Camera cam;

    private float targetZoom;
    private float zoomSpeed = 3;
    [SerializeField] private float zoomLerpSpeed = 10;
    [SerializeField] private float maxZoomOut = 20f;

    private CinemachineVirtualCamera cvc;

    [SerializeField] private GameObject[] cubes;
    [SerializeField] private int wurmInt;


    private GameObject followingWurm;

    private Transform initalTransform;

    private bool startvalue;
    private void Start()
    {

        cam = Camera.main;
        zoomFloat = cam.orthographicSize;
        cvc = cam.GetComponent<CinemachineVirtualCamera>();
        ChangeTagForFocus();
        initalTransform = transform;

       


    }

    void Update()
    {

      


        if (TurnOrder.PlayerAnimationDone())
           {
        


           wurmInt = Mathf.Clamp(wurmInt, 0, (cubes.Length - 1));


           

            

            if (startvalue)
            {
                    targetZoom = 10f;
                    startvalue = false;
            }

            


        



            float scrolldata;
            scrolldata = Input.GetAxis("Mouse ScrollWheel");
            


       
            
            cvc.Follow = followingWurm.transform;

            targetZoom -= scrolldata * zoomSpeed;

            if (targetZoom >= maxZoomOut)
            {

                cvc.Follow = initalTransform;



            }


        }
        else
        {

            cvc.Follow = initalTransform;
            targetZoom = 20f;
            startvalue=true;


        }
        targetZoom = Mathf.Clamp(targetZoom, 5f, maxZoomOut + 5);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);








    }

    public void ChangeTagForFocus()
    {
        
        
        cubes = GameObject.FindGameObjectsWithTag(TurnOrder.CurrentPlayerName());
        wurmInt = 0;
        



            //cvc.Follow = cubes[0].transform;

    }

    public void ChangeFocus(GameObject follow)
    {

        followingWurm = follow;


    }



}
