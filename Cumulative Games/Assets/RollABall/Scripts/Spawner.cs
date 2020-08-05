using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject IcyCube;
    public Vector3 SpawnAxis;
    public Vector3 location;

    public Collider[] colliders;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        int spawnedLocation = 0;
        while (spawnedLocation <= 9)
        {
            Vector3 location = new Vector3(0,0,0);
            bool canSpanHere = false;
            int numberOfTry = 0;

            while (!canSpanHere) { 
            location = new Vector3(Random.Range(-SpawnAxis.x, SpawnAxis.x), SpawnAxis.y, Random.Range(-SpawnAxis.z, SpawnAxis.z));
            Instantiate(IcyCube, location, Quaternion.identity);
            spawnedLocation++;

            canSpanHere = PreventSpawnOverlap(location);
            if (canSpanHere) { break; }
            if(numberOfTry > 50) { break; }
            }
        }
    }

    // Update is called once per frame
    public bool PreventSpawnOverlap(Vector3 location)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        for(int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.z;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;

            float lowerExtent = centerPoint.z - height;
            float upperExtent = centerPoint.z + height;

            if(location.x >=leftExtent && location.x >= rightExtent) 
            { 
                if (location.z >= lowerExtent && location.z >= upperExtent)
                {
                    return false;
                }   
            }            
        }
        return true;
    }
}
