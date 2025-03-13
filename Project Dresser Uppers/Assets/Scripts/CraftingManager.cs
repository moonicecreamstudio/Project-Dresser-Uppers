using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public InventorySlot materialSlot1;
    public InventorySlot materialSlot2;
    public InventorySlot materialSlot3;

    InventoryItem materialInSlot1;

    Recipes recipes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (materialSlot1.GetComponentInChildren<InventoryItem>() != null)
        {
            materialInSlot1 = materialSlot1.GetComponentInChildren<InventoryItem>();
        }
        
        //Debug.Log(materialInSlot1.count);

        //if (materialInSlot1.count == recipes.materialRequired)
        //{

        //}
    }
}
