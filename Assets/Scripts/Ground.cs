using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BuildingBlock"))
        {
            if (!other.gameObject.GetComponent<BuildingBlock>().firstBlock)
                HeadManager.Instance.Defeat();
        }
    }
}