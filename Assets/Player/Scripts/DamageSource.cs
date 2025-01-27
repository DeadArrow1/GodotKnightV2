using UnityEngine;

public class DamageSource : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SkeletonAI>())
        {
            Debug.Log("Skeleton hit");
        }
    }
}
