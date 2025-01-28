using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPBar : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private TextMeshProUGUI XPValues;

    public Slider slider;


    private void Update()
    {
        SetNeededXP(gameData.NeededXP);
        SetCurrentXP(gameData.CurrentXP);

        XPValues.text = gameData.CurrentXP + "/" + gameData.NeededXP;
    }

    public void SetNeededXP(int XP)
    {
        slider.maxValue = XP;
        slider.value = XP;
    }

    public void SetCurrentXP(int XP)
    {
        slider.value = XP;
    }
}

