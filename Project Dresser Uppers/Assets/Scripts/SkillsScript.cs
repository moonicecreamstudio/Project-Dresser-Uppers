using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsScript : MonoBehaviour
{
    public float skillTimer;
    public float skillCooldownTime;
    public GameObject skillButton;
    Player playerScript;
    public bool skillActivated;
    public float percentageFill;
    public GameObject enemyList;

    public enum SkillType
    {
        Damage,
        Healing,
        Buff
    }

    public SkillType skillType;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>(); // Will have to come back to this if destroying the player object is required.
        //skillButton = transform.GetComponentInChildren<GameObject>(); // Will find a better solution
        percentageFill = 0;
        skillActivated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (skillActivated == true)
        {
            skillButton.GetComponent<Button>().interactable = false;
            skillTimer += Time.deltaTime;

            percentageFill = (skillTimer / skillCooldownTime);
            skillButton.GetComponent<Image>().fillAmount = percentageFill;

            if (skillTimer >= skillCooldownTime)
            {
                skillActivated = false;
                skillButton.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void activateSkill()
    {
        if (skillType == SkillType.Healing)
        {
            playerScript.currentHealth += (playerScript.maxHealth / 2);
            skillActivated = true;
            skillTimer = 0;
            TelemetryLogger.Log(this, "Heal", playerScript.levelProgression.timer.ToString());
        }

        if (skillType == SkillType.Damage)
        {
            foreach (Transform child in enemyList.transform)
            {
                var enemy = child.GetComponent<EnemyScript>();
                enemy.Death();
            }
            skillActivated = true;
            skillTimer = 0;
            TelemetryLogger.Log(this, "Rend", playerScript.levelProgression.timer.ToString());
        }
    }
}
