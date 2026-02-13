using UnityEngine;

public class BuildingBlockMovement : MonoBehaviour
{
    public Transform ropePivot; // The point where rope attaches
    public BuildingBlock block;
    public float swingSpeed = 1f;
    public float swingAngle = 30f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate swing angle using sine wave
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        
        // Apply rotation to rope pivot
        ropePivot.localRotation = Quaternion.Euler(0, 0, angle);
        
        // Drop block
        if (Input.GetKey(KeyCode.Space) && block != null)
        {
            block.transform.SetParent(null);
            block.transform.localRotation = Quaternion.Euler(0, 0, angle);
            block.released = true;
            block = null;
        }
    }
}
