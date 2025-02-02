using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    public void OnPlayButton()
    {
        


        SceneManager.LoadScene(1);
        gameData.ResetPlayer();

    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

}
