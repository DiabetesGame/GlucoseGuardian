using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HappyCellBox : MonoBehaviour
{
    GameObject objToDespawn;
    XRGrabInteractable interactable;
    bool cellIsHappy;
    Animator animator;
    [SerializeField] AudioClip clip;

    //Get animator on start
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Get gameobject on trigger enter
    private void OnTriggerEnter(Collider other)
    {
        objToDespawn = other.gameObject.GetComponentInParent<CellAnimations>().gameObject;
        //If its supposed to go in this box, get its script to see if its happy
        if (objToDespawn.CompareTag(gameObject.tag))
        {
            try { cellIsHappy = other.gameObject.GetComponentInParent<CellAnimations>().isHappy; } catch (NullReferenceException) { Debug.Log("get fucked lmao"); }

            //If its happy, start the despawn timer
            if (cellIsHappy)
            {
                objToDespawn.GetComponent<AudioSource>().PlayOneShot(clip);
                StartCoroutine(DespawnTimer());
            }
        }
    }

    //Play an animation, and despawn the object after 3 seconds
    IEnumerator DespawnTimer()
    {
        //set transform so it moves with the animation
        objToDespawn.transform.SetParent(gameObject.transform);

        //Disable the ability to grab it
        interactable = objToDespawn.GetComponent<XRGrabInteractable>();
        interactable.enabled = false;

        //Play the animation before we destroy it
        animator.Play("Base Layer.ShrinkAndMove");

        //Destroy it after 3 seconds
        yield return new WaitForSeconds(3);
        objToDespawn.gameObject.GetComponent<PooledCell>().ReleaseObject();
    }
}
