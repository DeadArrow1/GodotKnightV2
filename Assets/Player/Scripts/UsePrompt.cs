using UnityEngine;

public class UsePrompt : MonoBehaviour
{
    [SerializeField] public GameData gameData;
    [SerializeField] public GameObject usePrompt;

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
    }
}
