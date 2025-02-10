using UnityEngine;

public class Encounter : MonoBehaviour
{

    [SerializeField] private GameData gameData;

    [SerializeField] public Transform EncounterDialog;

    [SerializeField] public GameObject levelBlockFence;

    private bool playerInside;
    private bool rewardGiven=false;

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(gameData.encounterStarted==true)
        {
            gameData.showUsePrompt = false;
            playerInside = false;
        }
        
        else if (other.gameObject.GetComponent<PlayerController>())
        {
            gameData.showUsePrompt = true;
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            gameData.showUsePrompt = false;
            playerInside = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && playerInside )
        {
            EncounterDialog.gameObject.SetActive(true);
        }

        if(gameData.countEnemiesInEncounter == 0 && gameData.encounterStarted == true)
        {
            gameData.encounterEnded = true;
            Destroy(levelBlockFence);
        }

        if (!rewardGiven)
        {
            if (gameData.encounterStarted == true && gameData.encounterEnded == true && gameData.countEnemiesInEncounter == 0)
            {
                gameData.DamageBonusFromEncounters += gameData.EncounterRewardsOptions[gameData.SelectedRewardIndex].bonusDmg;
                gameData.HealthBonusFromEncounters += gameData.EncounterRewardsOptions[gameData.SelectedRewardIndex].bonusHP;
                gameData.ArmorBonusFromEncounters += gameData.EncounterRewardsOptions[gameData.SelectedRewardIndex].bonusArmor;
                gameData.RecalculateStats();
                gameData.RolledRewards.Clear();
                rewardGiven = true;
            }
        }
    }
}
