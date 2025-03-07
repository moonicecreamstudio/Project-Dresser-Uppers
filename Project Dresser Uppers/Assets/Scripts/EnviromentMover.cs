using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMover : MonoBehaviour
{
    GameObject enviroment;
    public Player playerScript;
    public float movementSpeed;
    Vector3 resetPosition;

    // Start is called before the first frame update
    void Start()
    {
        resetPosition = new Vector3(175, transform.position.y, transform.position.z);
        enviroment = GetComponent<GameObject>();
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isFighting == false)
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }

        if (transform.position.x <= -125)
        {
            transform.position = resetPosition;
        }
    }
}
