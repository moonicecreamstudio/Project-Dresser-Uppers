using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitManager : MonoBehaviour
{
    GameObject player;
    public GameObject top3D;
    public GameObject bottom3D;
    Player playerScript;

    public Material red;
    public Material blue;
    public Material green;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        top3D = GameObject.FindWithTag("3DTop");
        bottom3D = GameObject.FindWithTag("3DBottom");
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>(); // Will have to come back to this if destroying the player object is required.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RedTop()
    {
        playerScript.equippedTopStats[0] = 0;
        playerScript.equippedTopStats[1] = 0;
        playerScript.equippedTopStats[2] = 10;
        playerScript.equippedTopStats[3] = 0;
        playerScript.equippedTopStats[4] = 0;
        playerScript.equippedTopStats[5] = 0;
        playerScript.equippedTopStats[6] = 0;
        playerScript.equippedTopStats[7] = 0;
        playerScript.equippedTopStats[8] = 0;

        top3D.GetComponent<MeshRenderer>().material = red;
    }
    public void BlueTop()
    {
        playerScript.equippedTopStats[0] = 0;
        playerScript.equippedTopStats[1] = 0;
        playerScript.equippedTopStats[2] = 0;
        playerScript.equippedTopStats[3] = 10;
        playerScript.equippedTopStats[4] = 0;
        playerScript.equippedTopStats[5] = 0;
        playerScript.equippedTopStats[6] = 0;
        playerScript.equippedTopStats[7] = 0;
        playerScript.equippedTopStats[8] = 0;

        top3D.GetComponent<MeshRenderer>().material = blue;
    }
    public void GreenTop()
    {
        playerScript.equippedTopStats[0] = 0;
        playerScript.equippedTopStats[1] = 0;
        playerScript.equippedTopStats[2] = 0;
        playerScript.equippedTopStats[3] = 0;
        playerScript.equippedTopStats[4] = 10;
        playerScript.equippedTopStats[5] = 0;
        playerScript.equippedTopStats[6] = 0;
        playerScript.equippedTopStats[7] = 0;
        playerScript.equippedTopStats[8] = 0;

        top3D.GetComponent<MeshRenderer>().material = green;
    }
}
