using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    [SerializeField] Camera AnimationCamera;
    [SerializeField] Camera MainCamera;


    public void AnimaitonView()
    {
        AnimationCamera.enabled = false;
        MainCamera.enabled = true;
    }

    public void Playerview()
    {
        AnimationCamera.enabled = true;
        MainCamera.enabled = false;
    }
}
