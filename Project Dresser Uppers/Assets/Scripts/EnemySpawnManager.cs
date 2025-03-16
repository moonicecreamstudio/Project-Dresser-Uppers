using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public float timer;
    [SerializeField] private float redSlimeSpawnChance = 23.3f;
    [SerializeField] private float blueSlimeSpawnChance = 23.3f;
    [SerializeField] private float greenSlimeSpawnChance = 23.3f;
    [SerializeField] private float redGhostSpawnChance = 10.0f;
    [SerializeField] private float blueGhostSpawnChance = 10.0f;
    [SerializeField] private float greenGhostSpawnChance = 10.0f;
    public Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>(); // Will have to come back to this if destroying the player object is required.
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 8 && playerScript.hasDied == false)
        {
            var chance = Random.Range(1.0f, 100.0f);

            if (chance <= redSlimeSpawnChance)
            {
                enemySpawner.SpawnRedSlime();
            }

            else if (chance <= redSlimeSpawnChance + blueSlimeSpawnChance)
            {
                enemySpawner.SpawnBlueSlime();
            }

            else if (chance <= redSlimeSpawnChance + blueSlimeSpawnChance + greenSlimeSpawnChance)
            {
                enemySpawner.SpawnGreenSlime();
            }

            else if (chance <= redSlimeSpawnChance + blueSlimeSpawnChance + greenSlimeSpawnChance + redGhostSpawnChance)
            {
                enemySpawner.SpawnRedGhost();
            }

            else if (chance <= redSlimeSpawnChance + blueSlimeSpawnChance + greenSlimeSpawnChance + redGhostSpawnChance + blueGhostSpawnChance)
            {
                enemySpawner.SpawnBlueGhost();
            }

            else if (chance <= redSlimeSpawnChance + blueSlimeSpawnChance + greenSlimeSpawnChance + redGhostSpawnChance + blueGhostSpawnChance + greenGhostSpawnChance)
            {
                enemySpawner.SpawnGreenGhost();
            }
            timer = 0;
        }
    }
}
