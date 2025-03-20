using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{

    public LevelProgression levelProgression;
    public GameObject victoryText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levelProgression.progress.value >= 100)
        {
            victoryText.SetActive(true);
        }
    }
}
