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
        Trash,
        None
    }

    public AllowedItemType allowedItemType;
    public CraftingManager craftingManager;

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
            if (IsValidDrop(inventoryItem))
            {
                inventoryItem.parentAfterDrag = transform;
            }
        }
        else if (transform.childCount == 1)
        {
            if (itemInSlot.item == inventoryItem.item && itemInSlot.item.stackable == true && inventoryItem.item.stackable == true) // Merge items if same item
            {
                MergeItems(itemInSlot, inventoryItem);
            }
            else
            {
                InventorySlot previousSlot = inventoryItem.parentBeforeDrag.GetComponentInParent<InventorySlot>();

                if (allowedItemType == AllowedItemType.All && inventoryItem.itemID != craftingManager.craftedItemID)
                {
                    if (IsValidSwap(previousSlot, itemInSlot))
                    {
                        SwapItems(itemInSlot, inventoryItem);
                    }
                }
                else if (IsMatchingItemType(allowedItemType, inventoryItem.itemType) && inventoryItem.itemID != craftingManager.craftedItemID)
                {
                    SwapItems(itemInSlot, inventoryItem);
                }

                if (allowedItemType == AllowedItemType.Trash && inventoryItem.itemID != craftingManager.craftedItemID)
                {
                    Destroy(itemInSlot.gameObject);
                    inventoryItem.parentAfterDrag = transform;
                }
            }
        }
    }

    private bool IsValidDrop(InventoryItem item)
    {
        return allowedItemType == AllowedItemType.All ||
               (allowedItemType == AllowedItemType.Trash && item.itemID != craftingManager.craftedItemID) ||
               IsMatchingItemType(allowedItemType, item.itemType);
    }

    private bool IsValidSwap(InventorySlot prevSlot, InventoryItem itemInSlot)
    {
        return prevSlot.allowedItemType == AllowedItemType.All ||
               IsMatchingItemType(prevSlot.allowedItemType, itemInSlot.itemType) ||
               prevSlot.allowedItemType == AllowedItemType.Trash;
    }

    private bool IsMatchingItemType(AllowedItemType slotType, ItemType itemType)
    {
        return (slotType == AllowedItemType.Top && itemType == ItemType.Top) ||
               (slotType == AllowedItemType.Bottom && itemType == ItemType.Bottom) ||
               (slotType == AllowedItemType.Weapon && itemType == ItemType.Weapon) ||
               (slotType == AllowedItemType.Crafting && itemType == ItemType.Crafting);
    }

    private void SwapItems(InventoryItem itemInSlot, InventoryItem inventoryItem)
    {
        itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
        inventoryItem.parentAfterDrag = transform;
    }

    private void MergeItems(InventoryItem itemInSlot, InventoryItem inventoryItem)
    {
        int maxStack = 10;
        int totalQuantity = itemInSlot.count + inventoryItem.count;

        if (totalQuantity <= maxStack)
        {
            itemInSlot.count = totalQuantity;
            itemInSlot.RefreshCount();
            Destroy(inventoryItem.gameObject);
        }
        else
        {
            itemInSlot.count = maxStack;
            itemInSlot.RefreshCount();
            inventoryItem.count = totalQuantity - maxStack;
            inventoryItem.RefreshCount();
        }
    }

    //public void OnDrop(PointerEventData eventData)
    //{
    //    InventoryItem itemInSlot = transform.GetComponentInChildren<InventoryItem>();
    //    InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();

    //    if (transform.childCount == 0)
    //    {

    //        if (allowedItemType == AllowedItemType.Trash && inventoryItem.itemID != craftingManager.craftedItemID) 
    //        {
    //            inventoryItem.parentAfterDrag = transform;
    //        }

    //        if (allowedItemType == AllowedItemType.All)
    //        {
    //            inventoryItem.parentAfterDrag = transform;
    //        }

    //        if (allowedItemType == AllowedItemType.Top && inventoryItem.itemType == ItemType.Top)
    //        {
    //            inventoryItem.parentAfterDrag = transform;
    //        }

    //        if (allowedItemType == AllowedItemType.Bottom && inventoryItem.itemType == ItemType.Bottom)
    //        {
    //            inventoryItem.parentAfterDrag = transform;
    //        }

    //        if (allowedItemType == AllowedItemType.Weapon && inventoryItem.itemType == ItemType.Weapon)
    //        {
    //            inventoryItem.parentAfterDrag = transform;
    //        }

    //        if (allowedItemType == AllowedItemType.Crafting && inventoryItem.itemType == ItemType.Crafting)
    //        {
    //            inventoryItem.parentAfterDrag = transform;
    //        }
    //    }

    //    if (transform.childCount == 1) // Swap positions of the objects
    //    {
    //        InventorySlot previousInventorySlot = inventoryItem.parentBeforeDrag.GetComponentInParent<InventorySlot>();

    //        Debug.Log(previousInventorySlot.allowedItemType);

    //        if (allowedItemType == AllowedItemType.All && inventoryItem.itemID != craftingManager.craftedItemID) // If the dropped slot is All, and item isn't from crafting (Prevents swapping with crafted item)
    //        {
    //            if (previousInventorySlot.allowedItemType == AllowedItemType.Top && itemInSlot.itemType == ItemType.Top) // Checks if the previous slot matches "Top"
    //            {
    //                itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
    //                inventoryItem.parentAfterDrag = transform;
    //            }
    //            if (previousInventorySlot.allowedItemType == AllowedItemType.Bottom && itemInSlot.itemType == ItemType.Bottom) // Checks if the previous slot matches "Bottom"
    //            {
    //                itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
    //                inventoryItem.parentAfterDrag = transform;
    //            }
    //            if (previousInventorySlot.allowedItemType == AllowedItemType.Weapon && itemInSlot.itemType == ItemType.Weapon) // Checks if the previous slot matches "Weapon"
    //            {
    //                itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
    //                inventoryItem.parentAfterDrag = transform;
    //            }
    //            if (previousInventorySlot.allowedItemType == AllowedItemType.All) // If the previous item slot was set to "All"
    //            {
    //                itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
    //                inventoryItem.parentAfterDrag = transform;
    //            }
    //            if (previousInventorySlot.allowedItemType == AllowedItemType.Trash) // If the previous item slot was set to "Trash"
    //            {
    //                itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
    //                inventoryItem.parentAfterDrag = transform;
    //            }
    //        }

    //        if (allowedItemType == AllowedItemType.Top && inventoryItem.itemType == ItemType.Top && inventoryItem.itemID != craftingManager.craftedItemID)
    //        {
    //            itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
    //            inventoryItem.parentAfterDrag = transform;
    //        }

    //        if (allowedItemType == AllowedItemType.Bottom && inventoryItem.itemType == ItemType.Bottom && inventoryItem.itemID != craftingManager.craftedItemID)
    //        {
    //            itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
    //            inventoryItem.parentAfterDrag = transform;
    //        }

    //        if (allowedItemType == AllowedItemType.Weapon && inventoryItem.itemType == ItemType.Weapon && inventoryItem.itemID != craftingManager.craftedItemID)
    //        {
    //            itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
    //            inventoryItem.parentAfterDrag = transform;
    //        }
    //    }

    //    if (transform.childCount == 1 && allowedItemType == AllowedItemType.Trash && inventoryItem.itemID != craftingManager.craftedItemID)
    //    {
    //        Destroy(itemInSlot.gameObject); // Delete item
    //        inventoryItem.parentAfterDrag = transform; // Replace the item
    //    }
    //}
}
