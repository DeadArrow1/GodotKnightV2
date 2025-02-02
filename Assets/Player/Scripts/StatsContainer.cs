using UnityEngine;
using TMPro;

public class StatsContainer : MonoBehaviour
{

    [SerializeField] private GameData gameData;
    [SerializeField] private TextMeshProUGUI MaxHPStatText;
    [SerializeField] private TextMeshProUGUI DamageStatText;
    [SerializeField] private TextMeshProUGUI ArmorStatText;
    [SerializeField] private TextMeshProUGUI LvlStatText;


    // Update is called once per frame
    void Update()
    {
        MaxHPStatText.text = gameData.MaxHealth.ToString();
        DamageStatText.text = gameData.Damage.ToString();
        ArmorStatText.text = gameData.Armor.ToString();
        LvlStatText.text = gameData.PlayerLevel.ToString();
    }
}


