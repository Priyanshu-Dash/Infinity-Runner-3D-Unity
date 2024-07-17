using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject target;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(target, 1f);
        }
    }
}
