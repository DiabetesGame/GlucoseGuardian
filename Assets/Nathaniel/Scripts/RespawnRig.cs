using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnRig : MonoBehaviour
{
    private void OnEnable()
    {
        ObjDestroyBarrier.RespawnRig += Respawn;
    }

    private void OnDisable()
    {
        ObjDestroyBarrier.RespawnRig -= Respawn;
    }

    void Respawn()
    {
        transform.position = new Vector3(0.24f, 8.72f, -2.5f);
    }
}
