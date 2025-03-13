using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static EnemyScript;

[CreateAssetMenu(menuName = "Scriptable object/Recipes")]
public class Recipes : ScriptableObject
{
    [System.Serializable]
    public class MaterialRequired
    {
        public Item itemInput;
        public float quantity;
    }
    public MaterialRequired[] materialRequired;

    public string itemName;
    public string description;

    public Item itemOutput;
}
