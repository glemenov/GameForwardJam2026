using UnityEngine;

public class BuildingBlock : MonoBehaviour
{
    public bool released;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (released)
        {
            transform.localPosition -= Time.deltaTime * Vector3.up;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Collision! {other.gameObject.name}");
        
        if (other.collider.CompareTag("Ground"))
        {
            released = false;
        }
    }
}
