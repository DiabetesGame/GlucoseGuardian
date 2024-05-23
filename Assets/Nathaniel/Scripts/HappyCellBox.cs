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

    //Get animator on start
    private void Start()
    {
        animator = GetComponent<Animator>();
        animatedCellPosition = GetComponentInChildren<CellAnimations>().gameObject.transform;
        Debug.Log(animatedCellPosition.name);
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
        //set transform so it moves with the animation
        //objToDespawn.transform.SetParent(gameObject.transform);

        //Disable the ability to grab it
        interactable = objToDespawn.GetComponent<XRGrabInteractable>();
        interactable.enabled = false;

        //lerp and slerp position/rotation to that of the box
        for (float i = 0; i <= 1;)
        {
            Vector3.Lerp(releasedCellPosition.position, animatedCellPosition.position, i);
            Vector3.Slerp(releasedCellPosition.rotation.eulerAngles, animatedCellPosition.rotation.eulerAngles, i);

            i += Time.deltaTime;
            yield return null;
        }

        //swap models
        objToDespawn.gameObject.GetComponent<PooledCell>().ReleaseObject();
        animatedCellPosition.gameObject.SetActive(true);

        //Play the animation before we destroy it
        animator.Play("Base Layer.ShrinkAndMove");

        //Destroy it after 3 seconds
        yield return new WaitForSeconds(3);
        Debug.Log("Done");
    }
}
