using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject redSlime;
    public GameObject blueSlime;
    public GameObject greenSlime;
    public GameObject redGhost;
    public GameObject blueGhost;
    public GameObject greenGhost;
    public GameObject enemyList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRedSlime()
    {
        float[] variables = new float[3] { 14.25f, 15f, 15.75f};
        float result = variables[Random.Range(0, variables.Length)];
        Instantiate(redSlime, new Vector3(11, 42.2f, result), transform.rotation, enemyList.transform);
    }
    public void SpawnBlueSlime()
    {
        float[] variables = new float[3] { 14.25f, 15f, 15.75f };
        float result = variables[Random.Range(0, variables.Length)];
        Instantiate(blueSlime, new Vector3(11, 42.2f, result), transform.rotation, enemyList.transform);
    }
    public void SpawnGreenSlime()
    {
        float[] variables = new float[3] { 14.25f, 15f, 15.75f };
        float result = variables[Random.Range(0, variables.Length)];
        Instantiate(greenSlime, new Vector3(11, 42.2f, result), transform.rotation, enemyList.transform);
    }
    public void SpawnRedGhost()
    {
        float[] variables = new float[3] { 14.25f, 15f, 15.75f };
        float result = variables[Random.Range(0, variables.Length)];
        Instantiate(redGhost, new Vector3(11, 42.2f, result), transform.rotation, enemyList.transform);
    }
    public void SpawnBlueGhost()
    {
        float[] variables = new float[3] { 14.25f, 15f, 15.75f };
        float result = variables[Random.Range(0, variables.Length)];
        Instantiate(blueGhost, new Vector3(11, 42.2f, result), transform.rotation, enemyList.transform);
    }
    public void SpawnGreenGhost()
    {
        float[] variables = new float[3] { 14.25f, 15f, 15.75f };
        float result = variables[Random.Range(0, variables.Length)];
        Instantiate(greenGhost, new Vector3(11, 42.2f, result), transform.rotation, enemyList.transform);
    }
}
