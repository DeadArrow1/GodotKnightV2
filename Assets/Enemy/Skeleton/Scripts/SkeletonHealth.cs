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
    private GameObject HealthPotionPrefab;

    [SerializeField]
    private Transform LootDropLocation;

    private Animator myAnimator;

    [SerializeField]
    public Slider HPslider;
    private int currentHealth;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
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

        if (myAnimator.GetBool("IsHurt"))
        {
            myAnimator.SetBool("IsHurt", false);
        }
        else 
        {
                myAnimator.SetBool("IsHurt", true);
        }
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

            float DropChance = Random.value;
            if (DropChance > 0.9)
            {
                GameObject spawnInstance = Instantiate(HealthPotionPrefab);
                spawnInstance.transform.position = LootDropLocation.transform.position;
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
