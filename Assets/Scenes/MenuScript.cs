using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    public void OnPlayButton()
    {
        


        SceneManager.LoadScene(1);
        gameData.ResetPlayer();
        gameData.prepareEncounters();
        gameData.resetEncounterSettings();

    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

}
