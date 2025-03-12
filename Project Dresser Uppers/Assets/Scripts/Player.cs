using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public bool isFighting;
    public int currentEnemies;

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

    public List<float> equippedTopStats = new List<float>();
    public List<float> equippedBottomStats = new List<float>();
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

    // Start is called before the first frame update
    void Start()
    {
        isFighting = false;
        currentEnemies = 0;

        equippedTopStats[0] = 0;
        equippedTopStats[1] = 0;
        equippedTopStats[2] = 0;
        equippedTopStats[3] = 0;
        equippedTopStats[4] = 0;
        equippedTopStats[5] = 0;
        equippedTopStats[6] = 0;
        equippedTopStats[7] = 0;
        equippedTopStats[8] = 0;

        equippedBottomStats[0] = 0;
        equippedBottomStats[1] = 0;
        equippedBottomStats[2] = 0;
        equippedBottomStats[3] = 0;
        equippedBottomStats[4] = 0;
        equippedBottomStats[5] = 0;
        equippedBottomStats[6] = 0;
        equippedBottomStats[7] = 0;
        equippedBottomStats[8] = 0;
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
        fireDefenceStat = equippedTopStats[2] + equippedBottomStats[2];
        waterDefenceStat = equippedTopStats[3] + equippedBottomStats[3];
        grassDefenceStat = equippedTopStats[4] + equippedBottomStats[4];


        // Attack

    }

    public void ReceivePlayerDamage(float baseDamage, float fireDamage, float waterDamage, float grassDamage)
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


}
