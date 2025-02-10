using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillTreeButton : MonoBehaviour
{
    public Button skillTreeButton;
    [SerializeField] private GameData gameData;
    [SerializeField] private TextMeshProUGUI skillPointCountText;

    void Update()
    {
        if(gameData.SkillpointCount>0)
        {
            skillTreeButton.gameObject.SetActive(true);
            skillPointCountText.text = gameData.SkillpointCount.ToString();


        }
        else
        {

            skillTreeButton.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            skillTreeButton.onClick.Invoke();
        }
    }
}
