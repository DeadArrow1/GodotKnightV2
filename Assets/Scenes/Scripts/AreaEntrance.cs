using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string transitionName;
    [SerializeField] private GameData gameData;

    private void Start()
    {
        if(transitionName==SceneManagement.Instance.SceneTransitionName)
        {
            PlayerController.Instance.transform.position = this.transform.position;
            CameraController.Instance.SetPlayerCameraFollow();
            gameData.AreaLevel += 1;
        }
    }
}
