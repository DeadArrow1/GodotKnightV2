using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);

        gameData.MaxHealth = 100;
        gameData.CurrentHealth = 100;

        gameData.NeededXP = 100;
        gameData.CurrentXP = 40;

        gameData.ResetSkillTree();
        gameData.GeneratePrerequisities();
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

}
