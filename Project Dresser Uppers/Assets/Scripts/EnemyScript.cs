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

    public bool moveTowardsPlayer;
    public float movementSpeed;

    // Stat variable of an enemy
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

    public float attackCooldownTimer;
    public float attackCooldownTime;
    public bool attackCooldownMode;

    public float receivedTotalDamage;

    public float hurtCooldownTimer;
    public float hurtCooldownTime;
    public bool hurtCooldownMode;

    // States
    bool attackMode;
    bool moveIn;
    bool moveOut;

    private float enemeyOffSet = 2.0f;

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
            Debug.Log("ouchie");
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
        playerScript.currentEnemies -= 1;
        Destroy(gameObject);
    }
}
