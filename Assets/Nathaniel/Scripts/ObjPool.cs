using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjPool : MonoBehaviour
{
    Transform spawnPoint;
    Transform destroyPoint;
    Vector3 spawnOffset = new Vector3(0, 0.1f, 0);
    [SerializeField] PooledObject objToSpawn;
    [SerializeField] int maxPoolSize = 5;
    public IObjectPool<PooledObject> pool;
    public bool insulinButtonPressed;

    public int totalCount;
    public int totalNum;

    int spawnedObjects;


    // Start is called before the first frame update
    void Start()
    {
        //Set numbers based on if its insulin or glucose poolF
        if (gameObject.CompareTag("InsulinKey"))
        {
            totalNum = 9;
            totalCount = 8;
        }
        else if (MyOptions.instance == null)
        {
            totalCount = 5;
        }
        else
        {
            totalNum = 0;

            if (MyOptions.instance.gameDifficulty == 0)
            {
                totalCount = 10;
            }
            else if (MyOptions.instance.gameDifficulty == 1)
            {
                totalCount = 15;
            }
            else if (MyOptions.instance.gameDifficulty == 2)
            {
                totalCount = 20;
            }
            else
            {
                totalCount = 5;
            }
        }
        //Get spawn and destroy locations
        var transforms = GetComponentsInChildren<Transform>();
        if (transforms != null )
        {
            foreach (Transform t in transforms)
            {
                if (t.gameObject.CompareTag("Spawn"))
                {
                    spawnPoint = t;
                }
                else
                {
                    destroyPoint = t;
                }
            }
        }

        pool = new ObjectPool<PooledObject>(CreateObj, OnGet, OnRelease, OnDestroyObj, maxSize: maxPoolSize);
        StartCoroutine(SpawnOnTimer());
    }

    //Creates more objects
    private PooledObject CreateObj()
    {
        PooledObject obj = Instantiate(objToSpawn, spawnPoint.position - spawnOffset, spawnPoint.rotation, transform);
        obj.SetPool(pool);
        return obj;
    }

    //Sets a pooled object to active and moves it to the spawn point
    private void OnGet(PooledObject obj)
    {
        obj.gameObject.SetActive(true);
        spawnedObjects++;
        obj.transform.position = spawnPoint.position;
        obj.GetComponent<Animator>().enabled = true;        

    }

    //Sets an object to inactive once it is released
    private void OnRelease(PooledObject obj)
    {
        obj.gameObject.SetActive(false);
        spawnedObjects--;
        obj.GetComponent<Animator>().enabled = false;
        if (obj.used)
        {
            totalNum++;
            obj.used = false;
        }

    }
    //Destroys object and makes sure its is counted as used
    private void OnDestroyObj(PooledObject obj)
    {
        Destroy(obj.gameObject);
        spawnedObjects--;
    }

    //Spawns a new object every second
    public IEnumerator SpawnOnTimer()
    {
        if (gameObject.CompareTag("InsulinKey"))
        {
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            insulinButtonPressed = true;
        }

        while (true)
        {
            if (spawnedObjects + totalNum <= totalCount && insulinButtonPressed)
            {
                pool.Get();
            }

            yield return new WaitForSeconds(1);
        }
    }
    public void InsulinButton()
    {
        totalNum -= 4;
        if (totalNum < 0)
        {
            totalNum = 0;
        }
    }
}
