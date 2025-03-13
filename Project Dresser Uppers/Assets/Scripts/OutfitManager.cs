using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitManager : MonoBehaviour
{
    [HideInInspector] public GameObject top3D;
    [HideInInspector] public GameObject bottom3D;
    [HideInInspector] public GameObject top2D;
    [HideInInspector] public GameObject bottom2D;
    [HideInInspector] public Player playerScript;

    public Material blank;

    public GameObject topSlot;
    public GameObject bottomSlot;
    public GameObject weaponSlot;

    void Start()
    {
        top3D = GameObject.FindWithTag("3DTop");
        bottom3D = GameObject.FindWithTag("3DBottom");
        top2D = GameObject.FindWithTag("2DTop");
        bottom2D = GameObject.FindWithTag("2DBottom");
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>(); // Will have to come back to this if destroying the player object is required.
    }

    void Update()
    {
        OutfitCheck(); // Putting this here is very expensive
    }

    public void OutfitCheck()
    {
        InventoryItem itemInTopSlot = topSlot.GetComponentInChildren<InventoryItem>();
        InventoryItem itemInBottomSlot = bottomSlot.GetComponentInChildren<InventoryItem>();
        InventoryItem itemInWeaponSlot = weaponSlot.GetComponentInChildren<InventoryItem>();

        if (itemInTopSlot == null)
        {
            playerScript.equippedTopStats[0] = 0;
            playerScript.equippedTopStats[1] = 0;
            playerScript.equippedTopStats[2] = 0;
            playerScript.equippedTopStats[3] = 0;
            playerScript.equippedTopStats[4] = 0;
            playerScript.equippedTopStats[5] = 0;
            playerScript.equippedTopStats[6] = 0;
            playerScript.equippedTopStats[7] = 0;
            playerScript.equippedTopStats[8] = 0;
            top3D.GetComponent<MeshRenderer>().material = blank;
            top2D.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            playerScript.equippedTopStats[1] = itemInTopSlot.baseDefenceStat;
            playerScript.equippedTopStats[2] = itemInTopSlot.fireDefenceStat;
            playerScript.equippedTopStats[3] = itemInTopSlot.waterDefenceStat;
            playerScript.equippedTopStats[4] = itemInTopSlot.grassDefenceStat;
            playerScript.equippedTopStats[5] = itemInTopSlot.baseAttackStat;
            playerScript.equippedTopStats[6] = itemInTopSlot.fireAttackStat;
            playerScript.equippedTopStats[7] = itemInTopSlot.waterAttackStat;
            playerScript.equippedTopStats[8] = itemInTopSlot.grassAttackStat;
            top3D.GetComponent<MeshRenderer>().material = itemInTopSlot.material;
            top2D.GetComponent<SpriteRenderer>().sprite = itemInTopSlot.display2DOutfit;
        }

        if (itemInBottomSlot == null)
        {
            playerScript.equippedBottomStats[0] = 0;
            playerScript.equippedBottomStats[1] = 0;
            playerScript.equippedBottomStats[2] = 0;
            playerScript.equippedBottomStats[3] = 0;
            playerScript.equippedBottomStats[4] = 0;
            playerScript.equippedBottomStats[5] = 0;
            playerScript.equippedBottomStats[6] = 0;
            playerScript.equippedBottomStats[7] = 0;
            playerScript.equippedBottomStats[8] = 0;
            bottom3D.GetComponent<MeshRenderer>().material = blank;
            bottom2D.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            playerScript.equippedBottomStats[1] = itemInBottomSlot.baseDefenceStat;
            playerScript.equippedBottomStats[2] = itemInBottomSlot.fireDefenceStat;
            playerScript.equippedBottomStats[3] = itemInBottomSlot.waterDefenceStat;
            playerScript.equippedBottomStats[4] = itemInBottomSlot.grassDefenceStat;
            playerScript.equippedBottomStats[5] = itemInBottomSlot.baseAttackStat;
            playerScript.equippedBottomStats[6] = itemInBottomSlot.fireAttackStat;
            playerScript.equippedBottomStats[7] = itemInBottomSlot.waterAttackStat;
            playerScript.equippedBottomStats[8] = itemInBottomSlot.grassAttackStat;
            bottom3D.GetComponent<MeshRenderer>().material = itemInBottomSlot.material;
            bottom2D.GetComponent<SpriteRenderer>().sprite = itemInBottomSlot.display2DOutfit;
        }
    }
}
