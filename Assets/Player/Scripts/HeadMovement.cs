using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    private PlayerController playerController;
    private void Awake()
    {

        playerController = GetComponentInParent<PlayerController>();
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }
    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, angle-15);           
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, angle-15);        
        }

    }
}
