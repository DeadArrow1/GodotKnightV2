using UnityEngine;

public class UsePrompt : MonoBehaviour
{
    [SerializeField] public GameData gameData;
    [SerializeField] public GameObject usePrompt;

    [SerializeField] public GameObject InventoryWindow;

    [SerializeField] public GameObject ESCMenu;

    void Update()
    {
        if (gameData.showUsePrompt == true)
        {
            usePrompt.SetActive(true);

        }
        else
        {
            usePrompt.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab) && InventoryWindow.activeInHierarchy)
        {
            InventoryWindow.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryWindow.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && ESCMenu.activeInHierarchy)
        {
            Time.timeScale = 1;
            ESCMenu.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            ESCMenu.SetActive(true);            
        }


    }
}
