using UnityEngine;
using TMPro;
public class DisplayAreaLevel : MonoBehaviour
{

    [SerializeField] private GameData gameData;
    [SerializeField] private TextMeshProUGUI AreaLevelText;
    void Update()
    {
        AreaLevelText.text ="Level "  + gameData.AreaLevel.ToString();
    }
}
