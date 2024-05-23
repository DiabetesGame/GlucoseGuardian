using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HappyCellBox : MonoBehaviour
{
    GameObject objToDespawn;
    XRGrabInteractable interactable;
    bool cellIsHappy;
    Animator animator;
    [SerializeField] AudioClip clip;
    Transform animatedCellPosition;
    Transform releasedCellPosition;
    Rigidbody cellRigidbody;

    //Get animator on start
    private void Start()
    {
        animator = GetComponent<Animator>();
        animatedCellPosition = GetComponentInChildren<CellAnimations>().transform;
        Debug.Log(animatedCellPosition.name);
        animatedCellPosition.gameObject.SetActive(false);
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
        releasedCellPosition = objToDespawn.transform;
        cellRigidbody = objToDespawn.GetComponent<Rigidbody>();    
        //set transform so it moves with the animation
        //objToDespawn.transform.SetParent(gameObject.transform);

        //Disable the ability to grab it
        interactable = objToDespawn.GetComponent<XRGrabInteractable>();
        interactable.enabled = false;

        //Remove colliders and physics
        cellRigidbody.isKinematic = true;
        cellRigidbody.useGravity = false;

        foreach (Collider collider in objToDespawn.GetComponents<Collider>())
        {
            collider.enabled = false;
        }

/*        //lerp and slerp position/rotation to that of the box
        for (float i = 0; i <= 1;)
        {
            Vector3.MoveTowards(releasedCellPosition.position, animatedCellPosition.position, Time.deltaTime);
            Vector3.MoveTowards(releasedCellPosition.rotation.eulerAngles, animatedCellPosition.rotation.eulerAngles, i);

            i += Time.deltaTime / 2;
            yield return new WaitForSeconds(Time.deltaTime);
        }*/

        //swap models
        objToDespawn.gameObject.GetComponent<PooledCell>().ReleaseObject();
        animatedCellPosition.gameObject.SetActive(true);

        //Play the animation before we destroy it
        animator.Play("Base Layer.ShrinkAndMove");

        //Destroy it after 3 seconds
        yield return new WaitForSeconds(2.0f);

        animatedCellPosition.gameObject.SetActive(false);
        Debug.Log("Done");
    }
}
