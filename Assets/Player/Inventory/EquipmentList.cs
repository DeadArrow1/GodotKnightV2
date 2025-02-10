using UnityEngine;
using TMPro;
public class EquipmentList : MonoBehaviour
{
    [SerializeField] public GameData gameData;
    [SerializeField] public TextMeshProUGUI Helmet;
    [SerializeField] public TextMeshProUGUI Shoulders;
    [SerializeField] public TextMeshProUGUI Gauntlets;
    [SerializeField] public TextMeshProUGUI Chest;
    [SerializeField] public TextMeshProUGUI Leggins;
    [SerializeField] public TextMeshProUGUI Boots;

    void Update()
    {
        if (Equipment.Helmet != null)
        {
            Helmet.text = "Helmet : " + Equipment.Helmet.name;
        }
        else
        {
            Helmet.text = "Helmet : null";
        }

        if (Equipment.Shoulders != null)
        {
            Shoulders.text = "Shoulders : " + Equipment.Shoulders.name;
        }
        else
        {
            Shoulders.text = "Shoulders : null";
        }

        if (Equipment.Gauntlets != null)
        {
            Gauntlets.text = "Gauntlets : " + Equipment.Gauntlets.name;
        }
        else
        {
            Gauntlets.text = "Gauntlets : null";
        }



        if (Equipment.Chest != null)
        {
            Chest.text = "Chest : " + Equipment.Chest.name;
        }
        else
        {
            Chest.text = "Chest : null";
        }


        if (Equipment.Leggins != null)
        {
            Leggins.text = "Leggins : " + Equipment.Leggins.name;
        }
        else
        {
            Leggins.text = "Leggins : null";
        }

        if (Equipment.Boots != null)
        {
            Boots.text = "Boots : " + Equipment.Boots.name;
        }
        else
        {
            Boots.text = "Boots : null";
        }

    }
}
