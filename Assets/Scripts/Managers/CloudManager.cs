using System;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public List<CloudSetup> cloudSetups = new List<CloudSetup>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (CloudSetup cloudSetup in cloudSetups)
        {
            foreach (var cloud in cloudSetup.clouds)
            {
                if (Vector3.Distance(cloud.transform.position, cloudSetup.endPoint.position) < 0.1f)
                {
                    cloud.position = cloudSetup.startPoint.position;
                }
                
                cloud.position = Vector3.MoveTowards(cloud.position, cloudSetup.endPoint.position , cloudSetup.cloudSpeed * Time.deltaTime);
            }
        }
    }

    [Serializable]
    public class CloudSetup
    {
        public Transform startPoint;
        public Transform endPoint;
        public float cloudSpeed;
        public List<Transform> clouds = new List<Transform>();
    }
}
