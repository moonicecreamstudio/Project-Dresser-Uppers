using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Enemy")]
public class Enemy : ScriptableObject
{
    [Header("Desciption")]
    public EnemyType enemyType;
    public Sprite image;

    [Header("Stats")]
    public float startingHealth;

    public float baseDefenceStat;
    public float fireDefenceStat;
    public float waterDefenceStat;
    public float grassDefenceStat;

    public float baseAttackStat;
    public float fireAttackStat;
    public float waterAttackStat;
    public float grassAttackStat;

    [Header("Material 1")]
    public Item item1;
    public float chance1;

    [Header("Material 2")]
    public Item item2;
    public float chance2;

    [Header("Material 3")]
    public Item item3;
    public float chance3;

    [Header("Material 4")]
    public Item item4;
    public float chance4;

    [Header("Material 5")]
    public Item item5;
    public float chance5;
}
public enum EnemyType
{
    RedSlime,
    BlueSlime,
    GreenSlime
}