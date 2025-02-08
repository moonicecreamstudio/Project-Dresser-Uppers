using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    GameObject character;
    public int rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        character = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        if (transform.rotation.y <= -180)
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
