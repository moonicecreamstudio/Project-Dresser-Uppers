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
        Instantiate(redSlime, new Vector3(11, Random.Range(41.8f,42.5f),15), transform.rotation);
    }
    public void SpawnBlueSlime()
    {
        Instantiate(blueSlime, new Vector3(11, Random.Range(41.8f, 42.5f), 15), transform.rotation);
    }
    public void SpawnGreenSlime()
    {
        Instantiate(greenSlime, new Vector3(11, Random.Range(41.8f, 42.5f), 15), transform.rotation);
    }
}
