using System.Collections;
using System.Collections.Generic;
using System.Xml;
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
    public float attackStat;
    public float defenceStat;
    public float element;

    public float attackCooldownTimer;
    public float attackCooldownTime;
    public bool attackCooldownMode;

    // States
    bool attackMode;
    bool moveIn;
    bool moveOut;

    private float enemeyOffSet = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        slime = gameObject;
        player = GameObject.FindWithTag("Player");
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>(); // Will have to come back to this if destroying the player object is required.
        moveTowardsPlayer = true;
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
        }

        if (moveTowardsPlayer == true)
        {
            Movement();
        }

    }

    public void Attack()
    {
        attackCooldownTimer += Time.deltaTime;
        if (attackCooldownTimer < 1 && attackCooldownMode == false)
        {
            playerScript.ReceivePlayerDamage(attackStat);
            attackCooldownMode = true;
        }

        if (attackCooldownTimer >= attackCooldownTime)
        {
            attackCooldownTimer = 0;
            attackCooldownMode = false;
        }
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
        Destroy(gameObject);
    }
}
