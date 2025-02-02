using UnityEngine;
using TMPro;


public class SkillTooltip : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI textfield;
    void Update()
    {
        transform.position = Input.mousePosition + new Vector3(5,5,0);
    }

    public void displayTooltip(string tooltipText)
    {

        textfield.text = tooltipText;

    }

}
