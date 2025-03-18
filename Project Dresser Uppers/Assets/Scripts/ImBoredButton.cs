using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImBoredButton : MonoBehaviour
{
    public Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TelemetryLogger.Log(this, "I'm bored", playerScript.levelProgression.timer.ToString());
        }
    }
}
