using UnityEngine;

public class DamageSource : MonoBehaviour
{

    [SerializeField] private int damageAmount = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Hitbox") && other.transform.parent.gameObject.GetComponent<SkeletonHealth>())
        {
            Debug.Log("Skeleton hit");
            SkeletonHealth skeletonHealth = other.transform.parent.gameObject.GetComponent<SkeletonHealth>();
            skeletonHealth.TakeDamage(damageAmount);
        }
    }
}
