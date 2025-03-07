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
    public GameObject enemy;
    // public GameObject enemyHealthBar;
    public float timer;
    public GameObject topCanvas;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Player");
        //enemyHealthBar = GameObject.FindWithTag("PlayerHealthBar");
        enemyScript = this.transform.parent.GetComponentInChildren<EnemyScript>();
        damage = GetComponent<TextMeshPro>();
        damage.text = enemyScript.receivedTotalDamage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            Destroy(gameObject);
        }

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (movementSpeed * Time.deltaTime), this.transform.position.z);
    }
}
