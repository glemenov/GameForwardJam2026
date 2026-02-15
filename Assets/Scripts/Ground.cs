using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BuildingBlock"))
        {
            var block = other.gameObject.GetComponent<BuildingBlock>();
            if (!block.firstBlock && block.falling)
                HeadManager.Instance.Defeat();
        }
    }
}