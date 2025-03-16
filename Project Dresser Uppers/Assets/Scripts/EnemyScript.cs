using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public GameObject slime;
    public GameObject player;

    public Player playerScript;
    public Transform endTarget;

    [System.Serializable] // Make sure when youre using it, the engine holds on to it
    public class MaterialDrop
    {
        public Item item;
        public float chance;
    }

    public MaterialDrop[] materialDrop;

    public InventoryManager inventoryManager;

    [Header("Movement")]

    public bool moveTowardsPlayer;
    public float movementSpeed;
    //private float enemeyOffSet = 2.0f;

    [Header("Parameters")]

    public float startingHealth;
    public float currentHealth;
    public float baseDefenceStat;

    public float fireDefenceStat;
    public float waterDefenceStat;
    public float grassDefenceStat;

    public float baseAttackStat;

    public float fireAttackStat;
    public float waterAttackStat;
    public float grassAttackStat;

    [Header("States")]

    public float attackCooldownTimer;
    public float attackCooldownTime;
    public bool attackCooldownMode;


    public float hurtCooldownTimer;
    public float hurtCooldownTime;
    public bool hurtCooldownMode;

    bool attackMode;
    bool escapeMode;
    bool moveIn;
    bool moveOut;

    public float receivedDamage;
    public float receivedFireDamage;
    public float receivedWaterDamage;
    public float receivedGrassDamage;
    public float receivedTotalDamage;

    [Header("UI")]

    private Vector3 damageTextSpawnPosition;
    public GameObject damageText;

    float endX;
    float endZ;

    // Start is called before the first frame update
    void Start()
    {
        slime = gameObject;
        player = GameObject.FindWithTag("Player");
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>(); // Will have to come back to this if destroying the player object is required.
        moveTowardsPlayer = true;
        playerScript.currentEnemies += 1;
        inventoryManager = GameObject.FindWithTag("InventoryManager").GetComponentInChildren<InventoryManager>();
        endTarget = GameObject.FindWithTag("EnemyEndTarget").GetComponentInChildren<Transform>();

        endX = endTarget.position.x + Random.Range(-2.25f, 2.25f);
        endZ = endTarget.position.z + Random.Range(-1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

        if (moveTowardsPlayer == true && playerScript.hasDied == false)
        {
            Movement();
        }

        if (transform.position.x <= endX && moveTowardsPlayer == true)
        {
            attackMode = true;
            moveTowardsPlayer = false;
        }

        if (attackMode == true && playerScript.hasDied == false)
        {
            Attack();
            ReceiveDamage();
        }

        if (currentHealth <= 0)
        {
            Death();
        }

        if (playerScript.hasDied == true)
        {
            moveTowardsPlayer = false;
            attackMode = false;
            escapeMode = true;
        }

        if (escapeMode == true)
        {
            Escape();
        }
    }

    public void Escape()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

        if (transform.position.x <= -10)
        {
            playerScript.currentEnemies -= 1;
            Destroy(gameObject);
        }
    }

    public void ReceiveDamage()
    {
        hurtCooldownTimer += Time.deltaTime;
        if (hurtCooldownTimer < 1 && hurtCooldownMode == false)
        {
            ReceivePlayerDamage(playerScript.baseAttackStat, playerScript.fireAttackStat, playerScript.waterAttackStat, playerScript.grassAttackStat);
            hurtCooldownMode = true;
        }

        if (hurtCooldownTimer >= hurtCooldownTime)
        {
            hurtCooldownTimer = 0;
            hurtCooldownMode = false;
        }
    }
    public void Attack()
    {
        attackCooldownTimer += Time.deltaTime;
        if (attackCooldownTimer < 1 && attackCooldownMode == false)
        {
            playerScript.ReceiveEnemyDamage(baseAttackStat, fireAttackStat, waterAttackStat, grassAttackStat);
            attackCooldownMode = true;
        }

        if (attackCooldownTimer >= attackCooldownTime)
        {
            attackCooldownTimer = 0;
            attackCooldownMode = false;
        }
    }

    public void ReceivePlayerDamage(float baseDamage, float fireDamage, float waterDamage, float grassDamage)
    {
        damageTextSpawnPosition = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);

        receivedDamage = 0;
        receivedFireDamage = 0;
        receivedWaterDamage = 0;
        receivedGrassDamage = 0;

        if (baseDamage > 0) // If player deals damage, use the formula, if not, no damage.
        {
            receivedDamage = baseDamage - baseDefenceStat;
            if (receivedDamage < 0) // Stops enemies from getting healed from attacks lower than the defence value of the player
            {
                receivedDamage = 0;
            }
        }
        if (fireDamage > 0)
        {
            receivedFireDamage = fireDamage - fireDefenceStat;
            if (receivedFireDamage < 0)
            {
                receivedFireDamage = 0;
            }
        }
        if (waterDamage > 0)
        {
            receivedWaterDamage = waterDamage - waterDefenceStat;
            if (receivedWaterDamage < 0)
            {
                receivedWaterDamage = 0;
            }
        }
        if (grassDamage > 0)
        {
            receivedGrassDamage = grassDamage - grassDefenceStat;
            if (receivedGrassDamage < 0)
            {
                receivedGrassDamage = 0;
            }
        }
        receivedTotalDamage = receivedDamage + receivedFireDamage + receivedWaterDamage + receivedGrassDamage;

        currentHealth -= receivedTotalDamage;
        Instantiate(damageText, damageTextSpawnPosition, transform.rotation, this.transform);
    }

    //IEnumerator Damage()
    //{

    //}

    //Non-Working Code
    //IEnumerator MoveIn()
    //{
    //    while (transform.position.x >= player.transform.position.x)
    //    {
    //        float Speed = 3;
    //        float Direction = Mathf.Sign(transform.position.x - player.transform.position.x);
    //        Vector3 MovePos = new Vector3(
    //            transform.position.x -1.0f + Direction * Speed, //MoveTowards on 1 axis
    //            transform.position.y, transform.position.z
    //        );
    //        transform.position = MovePos;
    //        Debug.Log("Started Coroutine at timestamp : " + Time.time);
    //    }
    //    yield return StartCoroutine(MoveOut());
    //}
    //IEnumerator MoveOut()
    //{
    //    while (transform.position.x <= player.transform.position.x + enemeyOffSet)
    //    {
    //        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    //        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    //    }
    //    yield return null;
    //    yield return new WaitForSeconds(2.0f);
    //}

    public void Movement()
    {
        if (transform.position.x > endX)
        {
            var step = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3 (endX, transform.position.y, endZ), step);
        }
        else
        {
            moveTowardsPlayer = false;
        }
    }

    public void Death()
    {
        float itemRoll = Random.Range(1, 101);

        if (materialDrop.Length > 0 && materialDrop[0] != null)
        {
            if (itemRoll > 0 && itemRoll <= materialDrop[0].chance)
            {
                Debug.Log("Material 1 get");

                bool result = inventoryManager.AddItem(materialDrop[0].item);
                if (result == true)
                {
                    Debug.Log("Item added");
                }
                else
                {
                    Debug.Log("Item not added");
                }
            }
        }
        if (materialDrop.Length > 1 && materialDrop[1] != null)
        {
            if (itemRoll > materialDrop[0].chance && itemRoll <= materialDrop[0].chance + materialDrop[1].chance)
            {
                Debug.Log("Material 2 get");

                bool result = inventoryManager.AddItem(materialDrop[1].item);
                if (result == true)
                {
                    Debug.Log("Item added");
                }
                else
                {
                    Debug.Log("Item not added");
                }
            }
        }
        if (materialDrop.Length > 2 && materialDrop[2] != null)
        {
            if (itemRoll > materialDrop[0].chance + materialDrop[1].chance && itemRoll <= materialDrop[0].chance + materialDrop[1].chance + materialDrop[2].chance)
            {
                Debug.Log("Material 3 get");

                bool result = inventoryManager.AddItem(materialDrop[2].item);
                if (result == true)
                {
                    Debug.Log("Item added");
                }
                else
                {
                    Debug.Log("Item not added");
                }
            }
        }

        playerScript.currentEnemies -= 1;
        Destroy(gameObject);
    }
}
