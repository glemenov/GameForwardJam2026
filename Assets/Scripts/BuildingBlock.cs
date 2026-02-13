using Managers;
using UnityEngine;

public class BuildingBlock : MonoBehaviour
{
    public bool released;
    public bool firstBlock;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (released)
        {
            transform.localPosition -= Vector3.up * (Time.deltaTime * ConfigsManager.Instance.buildingBlockConfig.blockFallingSpeed);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (released == false) return;
        
        if (other.collider.CompareTag("Ground") || other.collider.CompareTag("BuildingBlock"))
        {
            released = false;

            if (other.collider.CompareTag("BuildingBlock"))
            {
                float accuracy = CalculatePlacementAccuracy(other.gameObject);
                Debug.Log($"Accuracy {accuracy}");

                if (ConfigsManager.Instance.buildingBlockConfig.perfectScoreAllowed < accuracy)
                {
                    Debug.Log($"Perfect!");
                }
                
                HeadManager.Instance.playerDataManager.AddMoney(Mathf.Round(accuracy));

                return;
            }

            // We lose
            if (!firstBlock)
            {
                HeadManager.Instance.Defeat();
            }
        }
    }
    
    float CalculateTopFaceOverlap(Bounds baseBounds, Bounds topBounds)
    {
        // For top face placement, we care about X and Z axes (horizontal plane)
        // The Y axis (height) is handled separately
        
        // Calculate overlap on X axis
        float overlapX = Mathf.Max(0, 
            Mathf.Min(baseBounds.max.x, topBounds.max.x) - 
            Mathf.Max(baseBounds.min.x, topBounds.min.x));
        
        // Calculate overlap on Z axis
        float overlapZ = Mathf.Max(0, 
            Mathf.Min(baseBounds.max.z, topBounds.max.z) - 
            Mathf.Max(baseBounds.min.z, topBounds.min.z));
        
        return overlapX * overlapZ;
    }
    
    float CalculatePlacementAccuracy(GameObject topCube)
    {
        // Get the bounds of both cubes
        Bounds baseBounds = this.GetComponent<Renderer>().bounds;
        Bounds topBounds = topCube.GetComponent<Renderer>().bounds;
        
        // Calculate the overlapping area on the top face of the base cube
        float overlapArea = CalculateTopFaceOverlap(baseBounds, topBounds);
        
        // Area of the top face of the base cube
        float baseTopArea = baseBounds.size.x * baseBounds.size.z;
        
        // Calculate accuracy percentage (how much of the base's top is covered)
        float accuracy = (overlapArea / baseTopArea) * 100f;
        
        return Mathf.Clamp(accuracy, 0, 100);
    }
}
