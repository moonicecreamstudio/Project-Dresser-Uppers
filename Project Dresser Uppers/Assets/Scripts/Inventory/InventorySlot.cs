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

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();

            if (allowedItemType == AllowedItemType.Trash)
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
            InventoryItem itemInSlot = transform.GetComponentInChildren<InventoryItem>();
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            InventorySlot previousInventorySlot = inventoryItem.parentBeforeDrag.GetComponentInParent<InventorySlot>();

            Debug.Log(previousInventorySlot.allowedItemType);

            if (allowedItemType == AllowedItemType.All)
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

            if (allowedItemType == AllowedItemType.Top && inventoryItem.itemType == ItemType.Top)
            {
                itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
                inventoryItem.parentAfterDrag = transform;
            }

            if (allowedItemType == AllowedItemType.Bottom && inventoryItem.itemType == ItemType.Bottom)
            {
                itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
                inventoryItem.parentAfterDrag = transform;
            }

            if (allowedItemType == AllowedItemType.Weapon && inventoryItem.itemType == ItemType.Weapon)
            {
                itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
                inventoryItem.parentAfterDrag = transform;
            }
        }

        if (transform.childCount == 1 && allowedItemType == AllowedItemType.Trash)
        {
            InventoryItem itemInSlot = transform.GetComponentInChildren<InventoryItem>();
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            Destroy(itemInSlot.gameObject); // Delete item
            inventoryItem.parentAfterDrag = transform; // Replace the item
        }
    }
}
