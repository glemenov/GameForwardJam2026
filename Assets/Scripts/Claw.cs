using System.Collections.Generic;
using CodeMonkey.Toolkit.TFunctionTimer;
using DefaultNamespace;
using Managers;
using UnityEngine;

public class Claw : MonoBehaviour
{
    public List<GameObject> blockPrefabs = new List<GameObject>();
    public Transform ropePivot; // The point where rope attaches
    public BuildingBlock block;
    public Transform spawnPoint;
    public Stat respawnTime;
    public float swingSpeed = 1f;
    public float swingAngle = 30f;

    private BuildingBlock _lastDroppedBlock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        respawnTime.Reset();
    }

    private void Start()
    {
        HeadManager.Instance.playerDataManager.onBlockTierUpgraded += UpgradeCurrentBlock;
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
            _lastDroppedBlock = block;

            block.transform.SetParent(null);
            block.transform.localRotation = Quaternion.Euler(0, 0, 0);
            block.released = true;
            block = null;

            FunctionTimer.Create(() =>
            {
                var gmbj = Instantiate(blockPrefabs[HeadManager.Instance.playerDataManager.GetBlockTier()], spawnPoint.position, spawnPoint.rotation);
                gmbj.transform.SetParent(ropePivot);
                block = gmbj.GetComponent<BuildingBlock>();
            }, respawnTime.GetValue());
        }
        
        // Last building block is dropped, checking distance if we need to elevate claw
        if (_lastDroppedBlock != null && !_lastDroppedBlock.released)
        {
            Debug.Log($"Distance {Vector3.Distance(_lastDroppedBlock.transform.position, transform.position)}");
            if (Vector3.Distance(_lastDroppedBlock.transform.position, transform.position) < ConfigsManager.Instance.clawConfig.minDistanceForElevation)
            {
                transform.localPosition += Vector3.up * ConfigsManager.Instance.clawConfig.elevationModifier;
            }
        }
    }

    private void UpgradeCurrentBlock()
    {
        var gmbj = Instantiate(blockPrefabs[HeadManager.Instance.playerDataManager.GetBlockTier()], block.transform.position, block.transform.rotation);
        gmbj.transform.SetParent(ropePivot);
        
        Destroy(block);
        
        block = gmbj.GetComponent<BuildingBlock>();
    }
}