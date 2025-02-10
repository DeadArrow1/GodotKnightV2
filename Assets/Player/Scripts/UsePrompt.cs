using UnityEngine;

public class UsePrompt : MonoBehaviour
{
    [SerializeField] public GameData gameData;
    [SerializeField] public GameObject usePrompt;

    [SerializeField] public GameObject InventoryWindow;

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


    }
}
