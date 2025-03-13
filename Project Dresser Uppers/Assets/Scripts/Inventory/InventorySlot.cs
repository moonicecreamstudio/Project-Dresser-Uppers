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
        }

        if (transform.childCount == 1) // Swap positions of the objects
        {
            InventoryItem itemInSlot = transform.GetComponentInChildren<InventoryItem>();
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();

            if (allowedItemType == AllowedItemType.All)
            {
                itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
                inventoryItem.parentAfterDrag = transform;
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
