using CodeMonkey.Toolkit.TFunctionTimer;
using UnityEngine;

public class Claw : MonoBehaviour
{
    public GameObject buildingBlockPrefab;
    public Transform ropePivot; // The point where rope attaches
    public BuildingBlock block;
    public Transform spawnPoint;
    public float respawnTime = 1f;
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
            block.transform.localRotation = Quaternion.Euler(0, 0, 0);
            block.released = true;
            block = null;

            FunctionTimer.Create(() =>
            {
                var gmbj = Instantiate(buildingBlockPrefab, spawnPoint.position, spawnPoint.rotation);
                gmbj.transform.SetParent(ropePivot);
                block = gmbj.GetComponent<BuildingBlock>();
                
            }, respawnTime);
            
            transform.localPosition += Vector3.up;
        }
    }
}