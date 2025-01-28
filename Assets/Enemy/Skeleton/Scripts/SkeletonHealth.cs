using UnityEngine;

public class SkeletonHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private int XPYield = 20;

    [SerializeField] private GameData gameData;
    private int currentHealth;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        DetectDeath();
    }
    private void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            gameData.CurrentXP += XPYield;
            Destroy(gameObject);
        }
    }

}
