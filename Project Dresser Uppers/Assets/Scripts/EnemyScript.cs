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
    private float enemeyOffSet = 2.0f;

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

    public float receivedTotalDamage;

    public float hurtCooldownTimer;
    public float hurtCooldownTime;
    public bool hurtCooldownMode;

    bool attackMode;
    bool moveIn;
    bool moveOut;

    [Header("UI")]

    private Vector3 damageTextSpawnPosition;
    public GameObject damageText;

    // Start is called before the first frame update
    void Start()
    {
        slime = gameObject;
        player = GameObject.FindWithTag("Player");
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>(); // Will have to come back to this if destroying the player object is required.
        moveTowardsPlayer = true;
        playerScript.currentEnemies += 1;
        inventoryManager = GameObject.FindWithTag("InventoryManager").GetComponentInChildren<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }

        if (transform.position.x <= player.transform.position.x + enemeyOffSet)
        {
            attackMode = true;
            moveTowardsPlayer = false;
        }
        else
        {
            attackMode = false;
        }

        if (attackMode == true)
        {
            Attack();
            ReceiveDamage();
        }

        if (moveTowardsPlayer == true)
        {
            Movement();
        }

    }


    public void ReceiveDamage()
    {
        hurtCooldownTimer += Time.deltaTime;
        if (hurtCooldownTimer < 1 && hurtCooldownMode == false)
        {
            ReceiveDamageFromPlayer(playerScript.baseAttackStat);
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
            playerScript.ReceivePlayerDamage(baseAttackStat, fireAttackStat, waterAttackStat, grassAttackStat);
            attackCooldownMode = true;
        }

        if (attackCooldownTimer >= attackCooldownTime)
        {
            attackCooldownTimer = 0;
            attackCooldownMode = false;
        }
    }

    public void ReceiveDamageFromPlayer(float baseDamage)
    {
        damageTextSpawnPosition = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        receivedTotalDamage = baseDamage;
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
        if (transform.position.x >= player.transform.position.x + 1.0f)
        {
            transform.Translate(Vector3.right * -movementSpeed * Time.deltaTime);
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
