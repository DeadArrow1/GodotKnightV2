using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private TextMeshProUGUI HPValues;

    public Slider slider;


    private void Update()
    {
        SetMaxHealth(gameData.MaxHealth);
        SetHealth(gameData.CurrentHealth);

        HPValues.text = gameData.CurrentHealth + "/" + gameData.MaxHealth;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
