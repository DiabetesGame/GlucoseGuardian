using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CellAnimations : MonoBehaviour
{
    [SerializeField] Animation openCell;
    [SerializeField] AnimationClip[] animationClips;
    [SerializeField] ParticleSystem change;
    [SerializeField] GameObject HappyCell;
    [SerializeField] AudioSource HappySound;

    public bool isHappy = false;
    MeshCollider cellCollider;
    Rigidbody rigidbody;
    [SerializeField] InsulinOpener insulinOpener;

    // Start is called before the first frame update
    void Start()
    {
        cellCollider = GetComponent<MeshCollider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        isHappy = false;
        gameObject.GetComponent<XRGrabInteractable>().enabled = true;
        insulinOpener = GetComponentInChildren<InsulinOpener>();
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;

        foreach (Collider collider in GetComponents<Collider>())
        {
            collider.enabled = true;
        }
    }

    private void OnDisable()
    {
        CloseCell();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Open Sesame " + insulinOpener.keySlotted);
        if (other.gameObject.CompareTag("Glucose") && !isHappy && insulinOpener.keySlotted)
        {
            Debug.Log("Glucose Triggered");
            other.gameObject.GetComponentInParent<PooledObject>().used = true;
            other.gameObject.GetComponentInParent<PooledObject>().ReleaseObject();
            ChangeCell();
            isHappy = true;
        }
    }

    public void OpenCell()
    {
        openCell.clip = animationClips[0];
        openCell.Play();
        //cellCollider.convex = false;
        //rigidbody.useGravity = false;
        //rigidbody.isKinematic = true;
    }
    public void CloseCell()
    {
        openCell.clip = animationClips[1];
        openCell.Play();
    }
    void SmokePoof()
    {
        change.Play();
    }
    void ChangeCell()
    {
        SmokePoof();
        openCell.gameObject.SetActive(false);
        HappyCell.SetActive(true);

        if (HappySound != null)
        {
            HappySound.Play();
        }

        isHappy = true;
        //rigidbody.isKinematic = false;
        //rigidbody.useGravity = true;
        //cellCollider.convex = true;
    }
}
