using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject redSlime;
    public GameObject blueSlime;
    public GameObject greenSlime;



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
        Instantiate(redSlime, new Vector3(11, 42.2f, result), transform.rotation);
    }
    public void SpawnBlueSlime()
    {
        float[] variables = new float[3] { 14.25f, 15f, 15.75f };
        float result = variables[Random.Range(0, variables.Length)];
        Instantiate(blueSlime, new Vector3(11, 42.2f, result), transform.rotation);
    }
    public void SpawnGreenSlime()
    {
        float[] variables = new float[3] { 14.25f, 15f, 15.75f };
        float result = variables[Random.Range(0, variables.Length)];
        Instantiate(greenSlime, new Vector3(11, 42.2f, result), transform.rotation);
    }
}
