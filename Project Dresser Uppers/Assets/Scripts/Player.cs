using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public LevelProgression levelProgression;
    public bool isFighting;
    public int currentEnemies;

    public float maxHealth;
    public float currentHealth;
    bool hasDied;

    public float baseDefenceStat;

    public float fireDefenceStat;
    public float waterDefenceStat;
    public float grassDefenceStat;

    public float baseAttackStat;

    public float fireAttackStat;
    public float waterAttackStat;
    public float grassAttackStat;

    public List<float> equippedTopStats = new List<float>();
    public List<float> equippedBottomStats = new List<float>();
    public List<float> equippedWeaponStats = new List<float>();
    //private float[] equippedBottomStats = new float[9];
    //public float[] equippedTopStats = {0, 0, 0, 0, 0, 0, 0, 0, 0}; 
    //public float[] equippedBottomStats = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public float receivedDamage;
    public float receivedFireDamage;
    public float receivedWaterDamage;
    public float receivedGrassDamage;
    public float receivedTotalDamage;
    public GameObject receivedDamageText;
    public PlayerHealthUI healthUI;

    public TMPro.TextMeshProUGUI baseDefenceText;
    public TMPro.TextMeshProUGUI fireDefenceText;
    public TMPro.TextMeshProUGUI waterDefenceText;
    public TMPro.TextMeshProUGUI grassDefenceText;

    public TMPro.TextMeshProUGUI baseAttackText;
    public TMPro.TextMeshProUGUI fireAttackText;
    public TMPro.TextMeshProUGUI waterAttackText;
    public TMPro.TextMeshProUGUI grassAttackText;

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
        isFighting = false;
        currentEnemies = 0;

        equippedTopStats[0] = 0; // health
        equippedTopStats[1] = 0; // baseDefence
        equippedTopStats[2] = 0; // fireDefence
        equippedTopStats[3] = 0; // waterDefence
        equippedTopStats[4] = 0; // grassDefence
        equippedTopStats[5] = 0; // baseAttack
        equippedTopStats[6] = 0; // fireAttack
        equippedTopStats[7] = 0; // waterAttack
        equippedTopStats[8] = 0; // grassAttack

        equippedBottomStats[0] = 0; // health
        equippedBottomStats[1] = 0; // baseDefence
        equippedBottomStats[2] = 0; // fireDefence
        equippedBottomStats[3] = 0; // waterDefence
        equippedBottomStats[4] = 0; // grassDefence
        equippedBottomStats[5] = 0; // baseAttack
        equippedBottomStats[6] = 0; // fireAttack
        equippedBottomStats[7] = 0; // waterAttack
        equippedBottomStats[8] = 0; // grassAttack

        equippedWeaponStats[0] = 0; // health
        equippedWeaponStats[1] = 0; // baseDefence
        equippedWeaponStats[2] = 0; // fireDefence
        equippedWeaponStats[3] = 0; // waterDefence
        equippedWeaponStats[4] = 0; // grassDefence
        equippedWeaponStats[5] = 0; // baseAttack
        equippedWeaponStats[6] = 0; // fireAttack
        equippedWeaponStats[7] = 0; // waterAttack
        equippedWeaponStats[8] = 0; // grassAttack
    }

    // Update is called once per frame
    void Update()
    {
        baseDefenceText.text = baseDefenceStat.ToString();
        fireDefenceText.text = fireDefenceStat.ToString();
        waterDefenceText.text = waterDefenceStat.ToString();
        grassDefenceText.text = grassDefenceStat.ToString();

        baseAttackText.text = baseAttackStat.ToString();
        fireAttackText.text = fireAttackStat.ToString();
        waterAttackText.text = waterAttackStat.ToString();
        grassAttackText.text = grassAttackStat.ToString();

        Debug.Log(isFighting);
        if (currentEnemies > 0)
        {
            isFighting = true;
        }
        else if (currentEnemies <= 0)
        {
            isFighting = false;
        }

        // Stats

        // Defence
        baseDefenceStat = equippedTopStats[1] + equippedBottomStats[1] + equippedWeaponStats[1];
        fireDefenceStat = equippedTopStats[2] + equippedBottomStats[2] + equippedWeaponStats[2];
        waterDefenceStat = equippedTopStats[3] + equippedBottomStats[3] + equippedWeaponStats[3];
        grassDefenceStat = equippedTopStats[4] + equippedBottomStats[4] + equippedWeaponStats[4];


        // Attack
        baseAttackStat = equippedTopStats[5] + equippedBottomStats[5] + equippedWeaponStats[5];
        fireAttackStat = equippedTopStats[6] + equippedBottomStats[6] + equippedWeaponStats[6];
        waterAttackStat = equippedTopStats[7] + equippedBottomStats[7] + equippedWeaponStats[7];
        grassAttackStat = equippedTopStats[8] + equippedBottomStats[8] + equippedWeaponStats[8];

        // Health

        if (currentHealth <= 0)
        {
            if (hasDied == false)
            {
                PlayerDeath();
                hasDied = true;
            }
        }
    }

    public void ReceiveEnemyDamage(float baseDamage, float fireDamage, float waterDamage, float grassDamage)
    {
        receivedDamage = baseDamage - baseDefenceStat;
        if (receivedDamage < 0) // Stops players from getting healed from attacks lower than the defence value of the player
        {
            receivedDamage = 0;
        }
        receivedFireDamage = fireDamage - fireDefenceStat;
        if (receivedFireDamage < 0)
        {
            receivedFireDamage = 0;
        }

        receivedWaterDamage = waterDamage - waterDefenceStat;
        if (receivedWaterDamage < 0)
        {
            receivedWaterDamage = 0;
        }

        receivedGrassDamage = grassDamage - grassDefenceStat;
        if (receivedGrassDamage < 0)
        {
            receivedGrassDamage = 0;
        }

        receivedTotalDamage = receivedDamage + receivedFireDamage + receivedWaterDamage + receivedGrassDamage;

        // Show UI

        Instantiate(receivedDamageText);

        // Set the current health
        currentHealth -= receivedTotalDamage;

        // healthUI.PlayerHealthChange(); // Adding this line of code makes the enemy hit the player every frame...? Why is that?
    }

    public void PlayerDeath()
    {
        var data = new KillEventData()
        {
            enemiesAlive = currentEnemies,
            timePassedInSeconds = levelProgression.timer
        };
        
        TelemetryLogger.Log(this, "Player Death", data);
        Debug.Log("You died.");
    }
}
