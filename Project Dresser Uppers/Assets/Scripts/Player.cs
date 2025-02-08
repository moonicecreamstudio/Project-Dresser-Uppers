using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float baseDefenceStat;

    public float fireDefenceStat;
    public float waterDefenceStat;
    public float grassDefenceStat;

    public float baseAttackStat;

    public float fireAttackStat;
    public float waterAttackStat;
    public float grassAttackStat;

    public float[] equippedTopStats = {0, 0, 0, 0, 0, 0, 0, 0, 0}; 
    public float[] equippedBottomStats = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public float receivedDamage;
    public GameObject receivedDamageText;
    public PlayerHealthUI healthUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Stats

        grassDefenceStat = equippedTopStats[4];

        // Attack calculation
    }

    public void ReceivePlayerDamage(float baseDamage, float fireDamage, float waterDamage, float grassDamage)
    {
        receivedDamage = (baseDamage - baseDefenceStat) + (fireDamage - fireDefenceStat) + (waterDamage - waterDefenceStat) + (grassDamage - grassDefenceStat);
        if (receivedDamage < 0) // Stops players from getting healed from attacks lower than the defence value of the player
        {
            receivedDamage = 0;
        }

        // Show UI

        Instantiate(receivedDamageText);

        // Set the current health
        currentHealth -= receivedDamage;

        // healthUI.PlayerHealthChange(); // Adding this line of code makes the enemy hit the player every frame...? Why is that?
    }

}
