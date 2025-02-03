using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EncounterOptions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button FirstOptionButton;
    public Button SecondOptionButton;
    public Button ThirdOptionButton;

    [SerializeField] public TextMeshProUGUI Button0Name;
    [SerializeField] public TextMeshProUGUI Button0Description;

    [SerializeField] public TextMeshProUGUI Button1Name;
    [SerializeField] public TextMeshProUGUI Button1Description;

    [SerializeField] public TextMeshProUGUI Button2Name;
    [SerializeField] public TextMeshProUGUI Button2Description;

    public GameData gameData;

    

    void OnEnable()
    {
        Time.timeScale = 0;
        if (gameData.RolledRewards.Count == 0)
        {
            gameData.RolledRewards.Clear();
            gameData.RolledRewards.Add(0);
            gameData.RolledRewards.Add(1);
            gameData.RolledRewards.Add(2);
        }

        Button0Name.text = gameData.EncounterRewardsOptions[gameData.RolledRewards[0]].rewardName;
        Button0Description.text = gameData.EncounterRewardsOptions[gameData.RolledRewards[0]].description;

        Button1Name.text = gameData.EncounterRewardsOptions[gameData.RolledRewards[1]].rewardName;
        Button1Description.text = gameData.EncounterRewardsOptions[gameData.RolledRewards[1]].description;

        Button2Name.text = gameData.EncounterRewardsOptions[gameData.RolledRewards[2]].rewardName;
        Button2Description.text = gameData.EncounterRewardsOptions[gameData.RolledRewards[2]].description;


    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void FirstOptionClicked()
    {
        gameData.SelectedRewardIndex = gameData.RolledRewards[0];
        gameData.encounterStarted = true;
        gameObject.SetActive(false);

    }

    public void SecondOptionClicked()
    {
        gameData.SelectedRewardIndex = gameData.RolledRewards[1];
        gameData.encounterStarted = true;
        gameObject.SetActive(false);
        
    }

    public void ThirdOptionClicked()
    {
        gameData.SelectedRewardIndex = gameData.RolledRewards[2];
        gameData.encounterStarted = true;
        gameObject.SetActive(false);
    }
}
