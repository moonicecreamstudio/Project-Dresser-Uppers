using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI damage;
    public Player playerScript;
    public GameObject player;
    public GameObject playerHealthBar;
    public float timer;
    public GameObject topCanvas;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealthBar = GameObject.FindWithTag("PlayerHealthBar");
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>();
        damage.text = playerScript.receivedTotalDamage.ToString();
        topCanvas = GameObject.FindWithTag("TopCanvas");
        damage.transform.SetParent(topCanvas.transform, false);
        damage.transform.position = new Vector3(playerHealthBar.transform.position.x - 0.25f, playerHealthBar.transform.position.y - 0.25f, damage.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            Destroy(gameObject);
        }

        damage.transform.position = new Vector3(damage.transform.position.x, damage.transform.position.y + (movementSpeed * Time.deltaTime), damage.transform.position.z);
    }
}
