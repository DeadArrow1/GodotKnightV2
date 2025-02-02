using UnityEngine;

public class Encounter : MonoBehaviour
{

    [SerializeField] private GameData gameData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            gameData.showUsePrompt = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            gameData.showUsePrompt = false;
        }
    }
}
