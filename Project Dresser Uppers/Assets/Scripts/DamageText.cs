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
    public float timer;
    public GameObject topCanvas;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>();
        damage.text = playerScript.receivedDamage.ToString();
        topCanvas = GameObject.FindWithTag("TopCanvas");
        damage.transform.SetParent(topCanvas.transform, false);
        damage.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.0f, damage.transform.position.z);
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
