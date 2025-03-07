using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
        if (transform.childCount == 1) // Swap positions of the objects
        {
            InventoryItem itemInSlot = transform.GetComponentInChildren<InventoryItem>();
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            itemInSlot.transform.SetParent(inventoryItem.parentBeforeDrag, false);
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
