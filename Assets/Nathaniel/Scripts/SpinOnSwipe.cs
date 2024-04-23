using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpinOnSwipe : MonoBehaviour
{
    Vector3 pos1;
    Vector3 pos2;
    float distanceBetweenPoints;
    bool backwards;
    int poseState = 0; //0 = no position set, 1 = first position set, 2 = second position set
    Rigidbody objToSpeen;

    private void Start()
    {
        //Gets parent object so we can manipulate it later
        objToSpeen = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RayCastMouse();
    }

    void RayCastMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))  //If the ray collides with something...
        {
            if (poseState == 0)
            {
                pos1 = hit.point;
                poseState++;
            } else if (poseState == 1) 
            {
                pos2 = hit.point;
                poseState++;
            } else if (poseState == 2)
            {
                distanceBetweenPoints = Vector3.Distance(pos1, pos2);

                //If mouse going backwards
                if(pos1.x >= pos2.x)
                {
                    backwards = true;
                } else
                {
                    backwards=false;
                }

                if(distanceBetweenPoints >= 0.1f)
                {
                    SpinObject(distanceBetweenPoints);
                } else
                {
                    objToSpeen.freezeRotation = true;
                    objToSpeen.freezeRotation= false;
                }

                pos1 = pos2;
                poseState--;
            }
        }
    }

    void SpinObject(float distance)
    {
        objToSpeen.AddTorque(transform.up * (backwards ? -distance : distance) * 10);
    }


}
