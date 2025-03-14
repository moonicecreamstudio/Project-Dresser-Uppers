using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public enum AllowedItemType
    {
        All,
        Crafting,
        Top,
        Bottom,
        Weapon,
        Trash
    }

    public AllowedItemType allowedItemType;
    public CraftingManager craftingManager; // Remember to assign Crafting Manager to the Trash Slot

    public void Start()
    {
        craftingManager = GameObject.FindWithTag("CraftingManager").GetComponentInChildren<CraftingManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem itemInSlot = transform.GetComponentInChildren<InventoryItem>();
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();

        if (transform.childCount == 0)
        {

            if (allowedItemType == AllowedItemType.Trash && inventoryItem.itemID != craftingManager.craftedItemID) 
            {
                inventoryItem.parentAfterDrag = transform;
            }

            if (allowedItemType == AllowedItemType.All)
            {
                inventoryItem.parentAfterDrag = transform;
            }

            if (allowedItemType == AllowedItemType.Top && inventoryItem.itemType == ItemType.Top)
            {
                inventoryItem.parentAfterDrag = transform;
            }

            if (allowedItemType == AllowedItemType.Bottom && inventoryItem.itemType == ItemType.Bottom)
            {
                inventoryItem.parentAfterDrag = transform;
            }

            if (allowedItemType == AllowedItemType.Weapon && inventoryItem.itemType == ItemType.Weapon)
            {
                inventoryItem.parentAfterDrag = transform;
            }

            if (allowedItemType == AllowedItemType.Crafting && inventoryItem.itemType == ItemType.Crafting)
            {
                inventoryItem.parentAfterDrag = transform;
            }
        }

        if (transform.childCount == 1) // Swap positions of the objects
        {
            InventorySlot previousInventorySlot = inventoryItem.parentBeforeDrag.GetComponentInParent<InventorySlot>();

            Debug.Log(previousInventorySlot.allowedItemType);

            if (allowedItemType == AllowedItemType.All && inventoryItem.itemID != craftingManager.craftedItemID)
            {
                if (previousInventorySlot.allowedItemType == AllowedItemType.Top && itemInSlot.itemType == ItemType.Top) // Checks if the previous slot matches "Top"
                {
                    itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
                    inventoryItem.parentAfterDrag = transform;
                }
                if (previousInventorySlot.allowedItemType == AllowedItemType.Bottom && itemInSlot.itemType == ItemType.Bottom) // Checks if the previous slot matches "Bottom"
                {
                    itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
                    inventoryItem.parentAfterDrag = transform;
                }
                if (previousInventorySlot.allowedItemType == AllowedItemType.Weapon && itemInSlot.itemType == ItemType.Weapon) // Checks if the previous slot matches "Weapon"
                {
                    itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
                    inventoryItem.parentAfterDrag = transform;
                }
                if (previousInventorySlot.allowedItemType == AllowedItemType.All) // If the previous item slot was set to "All"
                {
                    itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
                    inventoryItem.parentAfterDrag = transform;
                }
                if (previousInventorySlot.allowedItemType == AllowedItemType.Trash) // If the previous item slot was set to "Trash"
                {
                    itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
                    inventoryItem.parentAfterDrag = transform;
                }
            }

            if (allowedItemType == AllowedItemType.Top && inventoryItem.itemType == ItemType.Top && inventoryItem.itemID != craftingManager.craftedItemID)
            {
                itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
                inventoryItem.parentAfterDrag = transform;
            }

            if (allowedItemType == AllowedItemType.Bottom && inventoryItem.itemType == ItemType.Bottom && inventoryItem.itemID != craftingManager.craftedItemID)
            {
                itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
                inventoryItem.parentAfterDrag = transform;
            }

            if (allowedItemType == AllowedItemType.Weapon && inventoryItem.itemType == ItemType.Weapon && inventoryItem.itemID != craftingManager.craftedItemID)
            {
                itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
                inventoryItem.parentAfterDrag = transform;
            }
        }

        if (transform.childCount == 1 && allowedItemType == AllowedItemType.Trash && inventoryItem.itemID != craftingManager.craftedItemID)
        {
            Destroy(itemInSlot.gameObject); // Delete item
            inventoryItem.parentAfterDrag = transform; // Replace the item
        }
    }
}
