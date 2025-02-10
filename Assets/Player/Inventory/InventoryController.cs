using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameData;

public class InventoryController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameData gameGata;

    private GameObject InventoryGrid;

    public GameObject InventoryItemPrefab;

    private GameObject HelmetSlot;
    private GameObject ShouldersSlot;
    private GameObject GauntletsSlot;
    private GameObject ChestSlot;
    private GameObject LegginsSlot;
    private GameObject BootsSlot;

    private void Awake()
    {
        InventoryGrid = GameObject.FindGameObjectWithTag("Inventory");


        HelmetSlot = GameObject.Find("Helmet");
        ShouldersSlot = GameObject.Find("Shoulders");
        GauntletsSlot = GameObject.Find("Gauntlets");
        ChestSlot = GameObject.Find("Chest");
        LegginsSlot = GameObject.Find("Leggins");
        BootsSlot = GameObject.Find("Boots");







        //InventoryGrid

        foreach (Item item in gameGata.Inventory)
        {
            GameObject spawnInstance = Instantiate(InventoryItemPrefab, InventoryGrid.transform);

            Sprite ItemImage = Resources.Load(item.imagePathInventory, typeof(Sprite)) as Sprite;

            Image CurrentImage = spawnInstance.GetComponent<Image>();
            CurrentImage.sprite = ItemImage;

            if (Equipment.Helmet != null && item.uniqueID == Equipment.Helmet.uniqueID)
            {
                spawnInstance.GetComponent<DragObject>().item = item;
                spawnInstance.transform.parent = HelmetSlot.transform;
                spawnInstance.transform.position = HelmetSlot.transform.position;
                spawnInstance.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
            }
            else if (Equipment.Chest != null && item.uniqueID == Equipment.Chest.uniqueID)
            {
                spawnInstance.GetComponent<DragObject>().item = item;
                spawnInstance.transform.parent = ChestSlot.transform;
                spawnInstance.transform.position = ChestSlot.transform.position;
                spawnInstance.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
            }
            else if (Equipment.Shoulders != null && item.uniqueID == Equipment.Shoulders.uniqueID)
            {
                spawnInstance.GetComponent<DragObject>().item = item;
                spawnInstance.transform.parent = ShouldersSlot.transform;
                spawnInstance.transform.position = ShouldersSlot.transform.position;
                spawnInstance.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
            }
            else if (Equipment.Gauntlets != null && item.uniqueID == Equipment.Gauntlets.uniqueID)
            {
                spawnInstance.GetComponent<DragObject>().item = item;
                spawnInstance.transform.parent = GauntletsSlot.transform;
                spawnInstance.transform.position = GauntletsSlot.transform.position;
                spawnInstance.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
            }
            else if (Equipment.Leggins != null &&  item.uniqueID == Equipment.Leggins.uniqueID)
            {
                spawnInstance.GetComponent<DragObject>().item = item;
                spawnInstance.transform.parent = LegginsSlot.transform;
                spawnInstance.transform.position = LegginsSlot.transform.position;
                spawnInstance.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
            }
            else if (Equipment.Boots != null && item.uniqueID == Equipment.Boots.uniqueID)
            {
                spawnInstance.GetComponent<DragObject>().item = item;
                spawnInstance.transform.parent = BootsSlot.transform;
                spawnInstance.transform.position = BootsSlot.transform.position;
                spawnInstance.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
            }
            else
            {
                spawnInstance.GetComponent<DragObject>().item = item;
                spawnInstance.transform.parent = InventoryGrid.transform;

            }
        }

    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
