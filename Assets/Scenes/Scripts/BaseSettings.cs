using UnityEngine;

public class BaseSettings : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CameraController.Instance.SetPlayerCameraFollow();
        GameManager.Instance.findGameOverUI();

        PlayerController.Instance.transform.position =new Vector3(0, 0, 0);
    }

    
}
