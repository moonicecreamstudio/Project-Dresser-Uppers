using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// using static UnityEditor.Progress;

public class CraftingManager : MonoBehaviour
{
    public InventorySlot materialSlot1;
    public InventorySlot materialSlot2;
    public InventorySlot materialSlot3;
    public InventorySlot outputSlot;
    bool itemSpawned;
    public InventoryManager inventoryManager;
    public int craftedItemID;

    public GameObject inventoryItemPrefab;

    InventoryItem materialInSlot1;
    InventoryItem materialInSlot2;

    public Image requiredMaterial1Image;
    public Image requiredMaterial2Image;

    public TextMeshProUGUI requiredMaterial1Quantity;
    public TextMeshProUGUI requiredMaterial2Quantity;

    public Recipes currentRecipe;
    public int currentNumberList;

    public Recipes[] topRecipes;
    public Recipes[] bottomRecipes;
    public Recipes[] weaponRecipes;

    private Dictionary<string, Recipes[]> recipeDictionary;
    private string currentCategory; // Stores "Top", "Bottom", or "Weapon"

    public TextMeshProUGUI equipmentName;
    public TextMeshProUGUI equipmentDescription;

    public Button topButton;
    public Button bottomButton;
    public Button weaponButton;

    public GameObject top3D;
    public GameObject bottom3D;
    public GameObject weapon3D;
    public GameObject preview;

    public Material[] color;

    [System.Serializable]

    public struct KillEventData
    {
        public float enemiesAlive;
        public float timePassedInSeconds;
        // items in inventory
        // equipment equipped
        // total EXP
    }

    // Start is called before the first frame update
    void Start()
    {
        recipeDictionary = new Dictionary<string, Recipes[]>
        {
            { "Top", topRecipes },
            { "Bottom", bottomRecipes },
            { "Weapon", weaponRecipes }
        };

        currentCategory = "Top";
        currentNumberList = 0;
        UpdateRecipe();

        // Update UI
        topButton.interactable = false;
        bottomButton.interactable = true;
        weaponButton.interactable = true;
        top3D.GetComponent<Renderer>().enabled = true;
        bottom3D.GetComponent<Renderer>().enabled = false;
        weapon3D.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        equipmentName.text = currentRecipe.itemName;
        equipmentDescription.text = currentRecipe.description;
        requiredMaterial1Image.sprite = currentRecipe.materialRequired[0].itemInput.image;
        if (currentRecipe.materialRequired.Length == 2)
        {
            requiredMaterial2Image.enabled = true;
            requiredMaterial2Image.sprite = currentRecipe.materialRequired[1].itemInput.image;
            requiredMaterial2Quantity.text = currentRecipe.materialRequired[1].quantity.ToString();
        } else
        {
            requiredMaterial2Image.sprite = null;
            requiredMaterial2Image.enabled = false;
            requiredMaterial2Quantity.text = "0";
        }

        requiredMaterial1Quantity.text = currentRecipe.materialRequired[0].quantity.ToString();


        top3D.GetComponent<MeshRenderer>().material = color[currentNumberList];
        bottom3D.GetComponent<MeshRenderer>().material = color[currentNumberList];
        weapon3D.GetComponent<MeshRenderer>().material = color[currentNumberList];


        if (materialSlot1.GetComponentInChildren<InventoryItem>() == null && currentRecipe.materialRequired.Length == 1) // If either item slots is null (won't work with single recipes.)
        {
            if (outputSlot.GetComponentInChildren<InventoryItem>() != null)
            {
                InventoryItem itemInOutput = outputSlot.GetComponentInChildren<InventoryItem>();
                Destroy(itemInOutput.gameObject); // Delete item
                itemSpawned = false;
            }
        }

        if (currentRecipe.materialRequired.Length == 2)
        {
            if (materialSlot2.GetComponentInChildren<InventoryItem>() == null || materialSlot1.GetComponentInChildren<InventoryItem>() == null)
            {
                if (outputSlot.GetComponentInChildren<InventoryItem>() != null)
                {
                    InventoryItem itemInOutput = outputSlot.GetComponentInChildren<InventoryItem>();
                    Destroy(itemInOutput.gameObject); // Delete item
                    itemSpawned = false;
                }
            }
        }

        // Checking material slots

        if (materialSlot1.GetComponentInChildren<InventoryItem>() != null) // Making the reference only if it's not null
        {
            materialInSlot1 = materialSlot1.GetComponentInChildren<InventoryItem>(); 

            // If the required materials are met in slot 1
            if (currentRecipe.materialRequired.Length == 1)
            {
                if (materialInSlot1.item == currentRecipe.materialRequired[0].itemInput && materialInSlot1.count >= currentRecipe.materialRequired[0].quantity)
                {
                    if (itemSpawned == false)
                    {
                        SpawnNewItem(currentRecipe.itemOutput, outputSlot);

                        itemSpawned = true;

                        craftedItemID = outputSlot.GetComponentInChildren<InventoryItem>().itemID;
                    }
                    if (itemSpawned == true)
                    {
                        // Checks if the crafted item has been placed in the inventory
                        for (int j = 0; j < inventoryManager.inventorySlots.Length; j++)
                        {
                            InventorySlot slot = inventoryManager.inventorySlots[j];
                            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                            if (itemInSlot != null && itemInSlot.itemID == craftedItemID)
                            {
                                // Consume Materials
                                materialInSlot1.count -= currentRecipe.materialRequired[0].quantity;
                                if (materialInSlot1.count == 0)
                                {
                                    Destroy(materialInSlot1.gameObject);
                                }
                                materialInSlot1.RefreshCount();
                                itemSpawned = false;
                                craftedItemID = 0;
                                TelemetryLogger.Log(this, itemInSlot.item.ToString());
                                break;
                            }
                        }
                    }
                }
                //else
                //{
                //    InventoryItem itemInOutput = outputSlot.GetComponentInChildren<InventoryItem>();
                //    Destroy(itemInOutput.gameObject); // Delete item
                //    itemSpawned = false;
                //}
            }

            if (materialSlot2.GetComponentInChildren<InventoryItem>() != null)
            {
                materialInSlot2 = materialSlot2.GetComponentInChildren<InventoryItem>();

                if (currentRecipe.materialRequired.Length == 2)
                {
                    if (materialInSlot1.item == currentRecipe.materialRequired[0].itemInput && materialInSlot1.count >= currentRecipe.materialRequired[0].quantity &&
                        materialInSlot2.item == currentRecipe.materialRequired[1].itemInput && materialInSlot1.count >= currentRecipe.materialRequired[1].quantity)
                    {
                        if (itemSpawned == false)
                        {
                            SpawnNewItem(currentRecipe.itemOutput, outputSlot);

                            itemSpawned = true;

                            craftedItemID = outputSlot.GetComponentInChildren<InventoryItem>().itemID;
                        }
                        if (itemSpawned == true)
                        {
                            // Checks if the crafted item has been placed in the inventory
                            for (int j = 0; j < inventoryManager.inventorySlots.Length; j++)
                            {
                                InventorySlot slot = inventoryManager.inventorySlots[j];
                                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                                if (itemInSlot != null && itemInSlot.itemID == craftedItemID)
                                {
                                    // Consume Materials 1
                                    materialInSlot1.count -= currentRecipe.materialRequired[0].quantity;
                                    if (materialInSlot1.count == 0)
                                    {
                                        Destroy(materialInSlot1.gameObject);
                                    }
                                    materialInSlot1.RefreshCount();
                                    // Consume Materials 2
                                    materialInSlot2.count -= currentRecipe.materialRequired[1].quantity;
                                    if (materialInSlot2.count == 0)
                                    {
                                        Destroy(materialInSlot2.gameObject);
                                    }
                                    materialInSlot2.RefreshCount();
                                    itemSpawned = false;
                                    craftedItemID = 0;
                                    TelemetryLogger.Log(this, itemInSlot.item.ToString ());
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }




        
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.IntialiseItem(item);
    }

    public void UpValue()
    {
        currentNumberList++;
        if (currentNumberList >= recipeDictionary[currentCategory].Length)
        {
            currentNumberList = 0;
        }
        UpdateRecipe();
    }
    public void DownValue()
    {
        currentNumberList--;
        if (currentNumberList < 0)
        {
            currentNumberList = recipeDictionary[currentCategory].Length - 1;
        }
        UpdateRecipe();
    }
    public void SwitchToTop()
    {
        currentCategory = "Top";
        UpdateRecipe();

        topButton.interactable = false;
        bottomButton.interactable = true;
        weaponButton.interactable = true;
        top3D.GetComponent<Renderer>().enabled = true;
        bottom3D.GetComponent<Renderer>().enabled = false;
        weapon3D.GetComponent<Renderer>().enabled = false;
    }

    public void SwitchToBottom()
    {
        currentCategory = "Bottom";
        UpdateRecipe();

        topButton.interactable = true;
        bottomButton.interactable = false;
        weaponButton.interactable = true;
        top3D.GetComponent<Renderer>().enabled = false;
        bottom3D.GetComponent<Renderer>().enabled = true;
        weapon3D.GetComponent<Renderer>().enabled = false;
    }

    public void SwitchToWeapon()
    {
        currentCategory = "Weapon";
        UpdateRecipe();

        topButton.interactable = true;
        bottomButton.interactable = true;
        weaponButton.interactable = false;
        top3D.GetComponent<Renderer>().enabled = false;
        bottom3D.GetComponent<Renderer>().enabled = false;
        weapon3D.GetComponent<Renderer>().enabled = true;
    }
    private void UpdateRecipe()
    {
        if (recipeDictionary.ContainsKey(currentCategory))
        {
            currentRecipe = recipeDictionary[currentCategory][currentNumberList];
        }

    }
}
