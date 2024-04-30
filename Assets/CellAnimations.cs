using System.Collections;
using System.Collections.Generic;
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
    MeshCollider collider;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<MeshCollider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        isHappy = false;
        gameObject.GetComponent<XRGrabInteractable>().enabled = true;
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
        if (other.gameObject.CompareTag("Glucose"))
        {
            other.gameObject.GetComponentInParent<PooledObject>().ReleaseObject();
            ChangeCell();
        }
    }

    public void OpenCell()
    {
        openCell.clip = animationClips[0];
        openCell.Play();
        collider.convex = false;
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
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
        rigidbody.isKinematic = false;        
        rigidbody.useGravity = true;
        collider.convex = true;

    }
}
