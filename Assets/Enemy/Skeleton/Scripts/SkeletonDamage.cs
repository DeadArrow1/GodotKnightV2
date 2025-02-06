using UnityEngine;

public class SkeletonDamage : MonoBehaviour
{
    [SerializeField] private int baseDamageAmount = 20;

    [SerializeField] private GameData gamedata;

    private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Hitbox") && other.transform.parent.gameObject.tag.Equals("Player"))
        {
            



            int damageAmount = baseDamageAmount + gamedata.AreaLevel * 2;
            
            PlayerController playerController = other.transform.parent.gameObject.GetComponent<PlayerController>();
            playerController.TakeDamage(damageAmount);
        }
    }
}
