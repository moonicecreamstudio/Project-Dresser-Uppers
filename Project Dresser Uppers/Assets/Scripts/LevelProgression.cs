using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgression : MonoBehaviour
{
    public Slider progress;
    float timer;

    public Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>();
        progress = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isFighting == false)
        {
            timer += Time.deltaTime;
        }
        progress.value = timer;
    }
}
