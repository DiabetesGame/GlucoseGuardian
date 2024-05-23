using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CellPool : MonoBehaviour
{
    Transform spawnPoint;
    Transform destroyPoint;
    Vector3 spawnOffset = new Vector3(0, 0.1f, 0);
    [SerializeField] PooledCell[] objToSpawn;
    [SerializeField] int maxPoolSize = 5;
    public IObjectPool<PooledCell> pool;

    int spawnedObjects;
    int cellNumber = 0;


    // Start is called before the first frame update
    void Awake()
    {
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


        pool = new ObjectPool<PooledCell>(CreateObj, OnGet, OnRelease, OnDestroyObj, maxSize: maxPoolSize);
        StartCoroutine(SpawnOnTimer());
    }

    //Creates more objects
    private PooledCell CreateObj()
    {
        PooledCell obj = Instantiate(objToSpawn[cellNumber], spawnPoint.position - spawnOffset, spawnPoint.rotation, transform);
        obj.SetPool(pool);
        return obj;
    }

    //Sets a pooled object to active and moves it to the spawn point
    private void OnGet(PooledCell obj)
    {
        obj.gameObject.SetActive(true);
        spawnedObjects++;
        obj.transform.position = spawnPoint.position;
        //obj.GetComponent<Animator>().enabled = true;
    }

    //Sets an object to inactive once it is released
    private void OnRelease(PooledCell obj)
    {
        obj.gameObject.SetActive(false);
        spawnedObjects--;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //obj.GetComponent<Animator>().enabled = false;
    }

    //Destroys object
    private void OnDestroyObj(PooledCell obj)
    {
        Destroy(obj.gameObject);
        spawnedObjects--;
    }

    //Spawns a new object every second
    public IEnumerator SpawnOnTimer()
    {
        while (true)
        {
            if (spawnedObjects <= maxPoolSize)
            {
                pool.Get();
                if(cellNumber <= 1)
                {
                    cellNumber++;
                }
                else
                {
                    cellNumber = 0;
                }
            }

            yield return new WaitForSeconds(1);
        }
    }
}
