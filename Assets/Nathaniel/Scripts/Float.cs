using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    Vector3 minHeight = new Vector3();
    Vector3 maxHeight = new Vector3();
    Vector3 offset = new Vector3(0, 2f, 0);
    float buffer = 0.7f;

    float forceScale;
    float scaleLerp;
    public int force = 1;

    Vector3 objTransform;
    Rigidbody objRB;

    // Start is called before the first frame update
    void Start()
    {
        minHeight = gameObject.transform.position;
        maxHeight = minHeight + offset;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        objRB = other.GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        objTransform = other.transform.position;
        scaleLerp = Mathf.InverseLerp(minHeight.y, maxHeight.y, objTransform.y);
        forceScale = Mathf.Lerp(force, force - 5, scaleLerp);
        if (forceScale <= 13)
        {
            //no force added
        }
        else if (forceScale >= 10)
        {
            objRB.AddRelativeForce(Vector3.up * forceScale, ForceMode.Acceleration);
        }

        Debug.Log(forceScale);
    }
}
