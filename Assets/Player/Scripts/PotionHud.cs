using UnityEngine;
using TMPro;
public class PotionHud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PotionCounter;
    [SerializeField] private GameData gameData;
    void Update()
    {
        PotionCounter.text = gameData.HealingPotionsCount.ToString();
    }
}
