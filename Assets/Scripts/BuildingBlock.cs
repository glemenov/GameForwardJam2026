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
        if (other.collider.CompareTag("Ground") || other.collider.CompareTag("BuildingBlock"))
        {
            released = false;
        }
    }
}
