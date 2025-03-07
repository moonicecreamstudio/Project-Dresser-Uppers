using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]

public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public ItemType itemType;

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;
}

public enum ItemType
{
    Crafting,
    Upgrade,
    Consumable
}

