using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] GameData gameData;
    private void OnTriggerEnter2D(Collider2D other)
    {
        int damageAmount = gameData.Damage;
        if (other.gameObject.tag.Equals("Hitbox") && other.transform.parent.gameObject.GetComponent<SkeletonHealth>())
        {
            Debug.Log("Skeleton hit for "+ damageAmount);
            SkeletonHealth skeletonHealth = other.transform.parent.gameObject.GetComponent<SkeletonHealth>();
            skeletonHealth.TakeDamage(damageAmount);
        }
    }
}
