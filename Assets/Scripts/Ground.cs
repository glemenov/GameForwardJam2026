using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Collision? {other.gameObject.name}");

        if (other.gameObject.CompareTag("BuildingBlock"))
        {
            var block = other.gameObject.GetComponent<BuildingBlock>();
            if (!block.firstBlock && block.released || block.falling)
            {
                HeadManager.Instance.Defeat();
                Debug.Log("Losing");
            }
        }
    }
}