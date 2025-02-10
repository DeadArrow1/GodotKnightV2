using UnityEngine;

using UnityEngine.EventSystems;


public class DropTarget : MonoBehaviour, IDropHandler

{
    [SerializeField]
    private RectTransform InventoryGrid;

    [SerializeField]
    public GameData gameData;

    private void Start()
    {
        InventoryGrid = GameObject.FindGameObjectWithTag("Inventory").GetComponent<RectTransform>();
    }
    public void OnDrop(PointerEventData eventData)

    {

        DragObject draggedItem = eventData.pointerDrag.GetComponent<DragObject>();

        if (draggedItem != null)

        {
            
            // Snap the dragged item to the drop target's position

            RectTransform draggedRectTransform = draggedItem.GetComponent<RectTransform>();

            RectTransform dropTargetRectTransform = GetComponent<RectTransform>();

            string SlotName = dropTargetRectTransform.name;

            if (draggedItem.GetComponent<DragObject>().item.slot.ToString().Equals(SlotName))
            {

                if (draggedRectTransform.parent != dropTargetRectTransform)

                {
                    if (SlotName == "Helmet")
                    {
                        Equipment.Helmet = draggedItem.GetComponent<DragObject>().item;
                        gameData.PlayerUpdateVisual = true;
                    }

                    if (SlotName == "Chest")
                    {
                        Equipment.Chest = draggedItem.GetComponent<DragObject>().item;
                        gameData.PlayerUpdateVisual = true;
                    }

                    if (SlotName == "Gauntlets")
                    {
                        Equipment.Gauntlets = draggedItem.GetComponent<DragObject>().item;
                        gameData.PlayerUpdateVisual = true;
                    }

                    if (SlotName == "Shoulders")
                    {
                        Equipment.Shoulders = draggedItem.GetComponent<DragObject>().item;
                        gameData.PlayerUpdateVisual = true;
                    }

                    if (SlotName == "Leggins")
                    {
                        Equipment.Leggins = draggedItem.GetComponent<DragObject>().item;
                        gameData.PlayerUpdateVisual = true;
                    }

                    if (SlotName == "Boots")
                    {
                        Equipment.Boots = draggedItem.GetComponent<DragObject>().item;
                        gameData.PlayerUpdateVisual = true;
                    }


                    AudioSource audioSource = draggedItem.GetComponent<AudioSource>();
                    AudioClip clipToPlay = (AudioClip)Resources.Load("DropToSlotItem", typeof(AudioClip));
                    audioSource.clip = clipToPlay;
                    audioSource.Play();

                    // Set the dragged item's position to the drop target's position

                    //draggedRectTransform.anchoredPosition = dropTargetRectTransform.anchoredPosition;

                    draggedRectTransform.position = dropTargetRectTransform.position;
                    draggedRectTransform.transform.SetParent(dropTargetRectTransform.transform);
                }
            }
            else if(InventoryGrid == dropTargetRectTransform)
            {
                if (draggedRectTransform.parent != dropTargetRectTransform)

                {

                    if (draggedItem.GetComponent<DragObject>().item.slot.ToString() == "Helmet")
                    {
                        //GameData.Item slottedItem = Equipment.Helmet;
                        Equipment.Helmet = null;
                        gameData.PlayerUpdateVisual = true;
                    }

                    if (draggedItem.GetComponent<DragObject>().item.slot.ToString() == "Chest")
                    {
                        //GameData.Item slottedItem = Equipment.Helmet;
                        Equipment.Chest = null;
                        gameData.PlayerUpdateVisual = true;
                    }

                    if (draggedItem.GetComponent<DragObject>().item.slot.ToString() == "Gauntlets")
                    {
                        //GameData.Item slottedItem = Equipment.Helmet;
                        Equipment.Gauntlets = null;
                        gameData.PlayerUpdateVisual = true;
                    }

                    if (draggedItem.GetComponent<DragObject>().item.slot.ToString() == "Shoulders")
                    {
                        //GameData.Item slottedItem = Equipment.Helmet;
                        Equipment.Shoulders = null;
                        gameData.PlayerUpdateVisual = true;
                    }

                    if (draggedItem.GetComponent<DragObject>().item.slot.ToString() == "Leggins")
                    {
                        //GameData.Item slottedItem = Equipment.Helmet;
                        Equipment.Leggins = null;
                        gameData.PlayerUpdateVisual = true;
                    }

                    if (draggedItem.GetComponent<DragObject>().item.slot.ToString() == "Boots")
                    {
                        //GameData.Item slottedItem = Equipment.Helmet;
                        Equipment.Boots = null;
                        gameData.PlayerUpdateVisual = true;
                    }


                    AudioSource audioSource = draggedItem.GetComponent<AudioSource>();
                    AudioClip clipToPlay = (AudioClip)Resources.Load("HoldItem", typeof(AudioClip));
                    audioSource.clip = clipToPlay;
                    audioSource.Play();



                }



                draggedRectTransform.position = dropTargetRectTransform.position;
                draggedRectTransform.transform.SetParent(dropTargetRectTransform.transform);




            }


            // Optionally: you can perform other actions here, such as disabling the original dragged item

            // draggedItem.gameObject.SetActive(false);

        }

    }

}
