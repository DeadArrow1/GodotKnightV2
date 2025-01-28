using UnityEngine;

public class DamageSource : MonoBehaviour
{

    [SerializeField] private int damageAmount = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SkeletonHealth>())
        {
            Debug.Log("Skeleton hit");
            SkeletonHealth skeletonHealth = other.gameObject.GetComponent<SkeletonHealth>();
            skeletonHealth.TakeDamage(damageAmount);
        }
    }
}
