using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SightSensor : MonoBehaviour 
{
    public Agent agent;

    List<Transform> trackedObjects;

    void Awake()
    {
        trackedObjects = new List<Transform>();
    }

    void Update()
    {
        List<Transform> iterateList = new List<Transform>(trackedObjects);
        foreach (Transform t in iterateList)
        {
            RaycastHit hit;
            Physics.Linecast(transform.position, t.position, out hit);
            if (hit.transform == t)
            {
                trackedObjects.Remove(t);
                agent.TransformInSight(t);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trackedObjects.Add(other.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (trackedObjects.Contains(other.transform))
        {
            trackedObjects.Remove(other.transform);
        }
    }   
}
