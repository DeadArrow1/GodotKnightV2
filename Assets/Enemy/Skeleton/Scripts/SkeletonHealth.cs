using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkeletonHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private int XPYield = 20;

    [SerializeField] private GameData gameData;

    [SerializeField] private Transform DamageText;

    [SerializeField] private TextMeshProUGUI DamageTextValue;

    [SerializeField]
    public Slider HPslider;
    private int currentHealth;

    private void Start()
    {
        startingHealth = startingHealth + 10 * gameData.AreaLevel;
        currentHealth = startingHealth;
    }

    private void Update()
    {
        SetMaxHealth(startingHealth);
        SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        DamageTextValue.text ="-" + damage.ToString();
        Animator HPAnimator=DamageText.GetComponent<Animator>();
        HPAnimator.SetTrigger("DamageTaken");
        Debug.Log(currentHealth);
        DetectDeath();
    }
    private void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            gameData.CurrentXP += XPYield;
            if (gameData.encounterStarted == true)
            {
                gameData.countEnemiesInEncounter = gameData.countEnemiesInEncounter - 1;
            }
            Destroy(gameObject);
        }
    }


    public void SetMaxHealth(int health)
    {
        HPslider.maxValue = health;
        HPslider.value = health;
    }

    public void SetHealth(int health)
    {
        HPslider.value = health;
    }
}
