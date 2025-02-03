using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameData gameData;
    public void Restart()
    {
        SceneManager.LoadScene(1);
        gameData.ResetPlayer();
        gameData.prepareEncounters();
    }
}
