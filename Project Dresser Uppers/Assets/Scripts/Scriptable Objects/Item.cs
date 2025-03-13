using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]

public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public ItemType itemType;

    public float baseDefenceStat;
    public float fireDefenceStat;
    public float waterDefenceStat;
    public float grassDefenceStat;

    public float baseAttackStat;
    public float fireAttackStat;
    public float waterAttackStat;
    public float grassAttackStat;

    [Header("Only UI")]
    public bool stackable = true;

    public Material material; // Temporarily used for change outfit color
    public Sprite display2DOutfit; 

    [Header("Both")]
    public Sprite image;
}

public enum ItemType
{
    Crafting,
    Top,
    Bottom,
    Weapon
}

