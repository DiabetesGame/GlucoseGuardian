using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroyBarrier : MonoBehaviour
{
    public Transform rigSpawn;

    public static event Action RespawnRig;

    private void Start()
    {
        RespawnRig.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = rigSpawn.position;
        }

        if (other.gameObject.tag.Contains("Cell"))
        {
            other.gameObject.GetComponent<PooledCell>().ReleaseObject();
        }else if (other.gameObject.CompareTag("InsulinKey"))
        {
            other.gameObject.GetComponent<PooledObject>().ReleaseObject();
        }
    }
}
