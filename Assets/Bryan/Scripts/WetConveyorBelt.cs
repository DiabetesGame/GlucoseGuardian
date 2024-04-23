using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetConveyorBelt : MonoBehaviour
{
    
    [SerializeField] public Transform[] movement;
    [SerializeField] public int speed = 1;

    private int nextSpot = 0;
    private int pathLength;


    // Start is called before the first frame update
    void Start()
    {
        pathLength = movement.Length;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move()
    {
        Debug.Log("pathLength");
        while(nextSpot < pathLength)
        {
            Vector3 start = this.transform.position;

            while (this.transform.position != movement[nextSpot].position)
            {
                float tempSpeed = Time.deltaTime * speed;
                this.transform.position = Vector3.MoveTowards(start, movement[nextSpot].position, tempSpeed);
                yield return null;
            }
            nextSpot++;
            Debug.Log(nextSpot);
        }
    }
}
