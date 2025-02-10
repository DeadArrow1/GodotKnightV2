using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameData gameData;
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        gameData.ResetPlayer();
        gameData.prepareEncounters();
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
