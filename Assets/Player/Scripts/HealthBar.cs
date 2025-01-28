using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    public Slider slider;


    private void Update()
    {
        SetMaxHealth(gameData.MaxHealth);
        SetHealth(gameData.CurrentHealth);
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
