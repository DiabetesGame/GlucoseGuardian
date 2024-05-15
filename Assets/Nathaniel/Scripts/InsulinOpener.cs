using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InsulinOpener : MonoBehaviour
{
    public UnityEvent openCell;
    public UnityEvent closeCell;

    ///Stuff for replacing materials
    [SerializeField] Material placementMat;
    MeshRenderer renderer;
    List<Material> keyMaterials = new List<Material>();

    //Stuff for checking if the thing is grabbed
    ObjIsGrabbed grabScript = null;
    bool grabbedOnEnter = false;
    [SerializeField] Collider insulin;
    [SerializeField] Collider glucose;
    public bool keySlotted = false;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.GetMaterials(keyMaterials);
    }

    private void OnEnable()
    {
        keySlotted = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InsulinKey"))
        {
            grabScript = other.GetComponent<ObjIsGrabbed>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        grabbedOnEnter = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (grabScript != null)
        {
            //If the key is released while in the trigger, destroy it and change the material so it looks like it snapped
            if (grabScript.hasBeenGrabbed 
                && !grabScript.grabbed
                && other.CompareTag("InsulinKey") 
                && !keySlotted)
            {
                keySlotted = true;
                other.gameObject.GetComponent<PooledObject>().used = true;
                other.gameObject.GetComponent<PooledObject>().ReleaseObject();
                ChangeMaterial();
                openCell.Invoke();
                //insulin.enabled = false;
                //glucose.enabled = true;
            }
            else
            {
                Debug.Log("Grabbed: " + !grabScript.grabbed + " GrabbedOnEnter: " + grabbedOnEnter);
            }
        }
    }

    void ChangeMaterial()
    {
        keyMaterials[0] = placementMat;
        renderer.SetMaterials(keyMaterials);
    }
}
