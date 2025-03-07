using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamageText : MonoBehaviour
{
    public TMPro.TextMeshPro damage;
    public EnemyScript enemyScript;
    public Transform enemy;
    // public GameObject enemyHealthBar;
    private float timer;
    public GameObject topCanvas;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.FindWithTag("Player");
        //enemyHealthBar = GameObject.FindWithTag("PlayerHealthBar");
        enemyScript = this.transform.parent.GetComponentInChildren<EnemyScript>();
        damage = GetComponent<TextMeshPro>();
        damage.text = enemyScript.receivedTotalDamage.ToString();
        Invoke("DestroyText", 2f); // Destroy the text after 2 seconds

        enemy = transform.parent;
        transform.SetParent(null, true);
        this.transform.position = enemy.position;
    }

    // Update is called once per frame

    void Update()
    {

        this.transform.position += Vector3.up * (movementSpeed * Time.deltaTime);
    }

    void DestroyText()
    {
        Destroy(gameObject);
    }
}
