using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider playerHealth;
    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.value = (playerScript.currentHealth / playerScript.maxHealth) * 100; // Very expensive, there's probably a better way to do this
    }
    public void PlayerHealthChange()
    {
        
    }
}
