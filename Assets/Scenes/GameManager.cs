using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject gameOverUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);

        gameOverUI.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void findGameOverUI()
    {
        gameOverUI = GameObject.Find("GameOverscreenHandle");
        
    }
}
