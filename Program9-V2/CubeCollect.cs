using UnityEngine;

public class CubeCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().CollectCube(gameObject);
        }
    }
}
