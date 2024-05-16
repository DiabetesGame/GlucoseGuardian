using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
//[RequireComponent (typeof(Collider))]

public class PooledObject : MonoBehaviour
{
    IObjectPool<PooledObject> objPool;
    public bool used = false;

    public void SetPool(IObjectPool<PooledObject> pool)
    {
        objPool = pool;
    }

    //This should (hopefully) stop errors when you exit play mode
    private void OnApplicationQuit()
    {
        objPool.Release(this);
    }

    public void ReleaseObject()
    {
        objPool.Release(this);
    }
}