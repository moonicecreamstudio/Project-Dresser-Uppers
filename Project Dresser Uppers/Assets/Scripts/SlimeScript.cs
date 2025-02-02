using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public GameObject slime;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        slime = gameObject;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= player.transform.position.x + 1.0f) 
        {
            transform.Translate(Vector3.right * -1.0f * Time.deltaTime);
        }


    }
}
