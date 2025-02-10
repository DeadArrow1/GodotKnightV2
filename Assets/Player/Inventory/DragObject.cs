
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;


using static GameData;

public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler

{

    private CanvasGroup canvasGroup;

    private RectTransform rectTransform;

    private RectTransform InventoryGrid;

    private Canvas canvas;

    [SerializeField]
    public Item item;




    private void Awake()

    {

        rectTransform = GetComponent<RectTransform>();

        canvasGroup = GetComponent<CanvasGroup>();

        canvas = GetComponentInParent<Canvas>();


        InventoryGrid = GameObject.FindGameObjectWithTag("Inventory").GetComponent<RectTransform>();

    }



    public void OnBeginDrag(PointerEventData eventData)

    {
        
        if (InventoryGrid != null)
        {
            LayoutRebuilder.MarkLayoutForRebuild(InventoryGrid);
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        AudioClip clipToPlay = (AudioClip)Resources.Load("HoldItem", typeof(AudioClip));
        audioSource.clip = clipToPlay;
        audioSource.Play();

        canvasGroup.alpha = 0.6f; // Make the item semi-transparent while dragging

        canvasGroup.blocksRaycasts = false; // Allow raycasts to pass through the item

    }


    public void OnDrag(PointerEventData eventData)

    {

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // Move the item with the pointer

    }


    public void OnEndDrag(PointerEventData eventData)

    {
        if (InventoryGrid != null)
        {
            LayoutRebuilder.MarkLayoutForRebuild(InventoryGrid);
        }
        if(transform.parent != InventoryGrid)
        {
            transform.position = transform.parent.position;
        }    

        canvasGroup.alpha = 1f; // Restore the item's opacity

        canvasGroup.blocksRaycasts = true; // Re-enable raycasts

    }

}
