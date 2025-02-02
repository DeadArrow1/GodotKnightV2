using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Linq;

public class SkillTooltip : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI textfield;
    [SerializeField] public GameData gameData;
    void Update()
    {
        transform.position = Input.mousePosition + new Vector3(5,5,0);
    }

    public void displayTooltip(Toggle callerSkillpoint)
    {
        int skillNumber = -1;
        string resultString = Regex.Match(callerSkillpoint.gameObject.name, @"\d+").Value;
        int.TryParse(resultString, out skillNumber);
        if (skillNumber >= 0)
        {
            textfield.text = gameData.Skills[skillNumber].skillTooltip;
        }
        else 
        {
            textfield.text = "Invalid skillnode name";
        }
    }

}
