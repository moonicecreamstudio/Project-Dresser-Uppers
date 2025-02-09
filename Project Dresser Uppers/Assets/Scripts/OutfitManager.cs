using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitManager : MonoBehaviour
{
    GameObject player;

    public GameObject top3D;
    public GameObject bottom3D;

    public GameObject top2D;
    public GameObject bottom2D;

    Player playerScript;

    public Material red;
    public Material blue;
    public Material green;

    public Sprite redTop;
    public Sprite redBottom;
    public Sprite blueTop;
    public Sprite blueBottom;
    public Sprite greenTop;
    public Sprite greenBottom;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        top3D = GameObject.FindWithTag("3DTop");
        bottom3D = GameObject.FindWithTag("3DBottom");
        top2D = GameObject.FindWithTag("2DTop");
        bottom2D = GameObject.FindWithTag("2DBottom");
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
        top2D.GetComponent<SpriteRenderer>().sprite = redTop;
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
        top2D.GetComponent<SpriteRenderer>().sprite = blueTop;
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
        top2D.GetComponent<SpriteRenderer>().sprite = greenTop;
    }

    public void RedBottom()
    {
        playerScript.equippedBottomStats[0] = 0;
        playerScript.equippedBottomStats[1] = 0;
        playerScript.equippedBottomStats[2] = 5;
        playerScript.equippedBottomStats[3] = 0;
        playerScript.equippedBottomStats[4] = 0;
        playerScript.equippedBottomStats[5] = 0;
        playerScript.equippedBottomStats[6] = 0;
        playerScript.equippedBottomStats[7] = 0;
        playerScript.equippedBottomStats[8] = 0;
        bottom3D.GetComponent<MeshRenderer>().material = red;
        bottom2D.GetComponent<SpriteRenderer>().sprite = redBottom;
    }
    public void BlueBottom()
    {
        playerScript.equippedBottomStats[0] = 0;
        playerScript.equippedBottomStats[1] = 0;
        playerScript.equippedBottomStats[2] = 0;
        playerScript.equippedBottomStats[3] = 5;
        playerScript.equippedBottomStats[4] = 0;
        playerScript.equippedBottomStats[5] = 0;
        playerScript.equippedBottomStats[6] = 0;
        playerScript.equippedBottomStats[7] = 0;
        playerScript.equippedBottomStats[8] = 0;

        bottom3D.GetComponent<MeshRenderer>().material = blue;
        bottom2D.GetComponent<SpriteRenderer>().sprite = blueBottom;
    }
    public void GreenBottom()
    {
        playerScript.equippedBottomStats[0] = 0;
        playerScript.equippedBottomStats[1] = 0;
        playerScript.equippedBottomStats[2] = 0;
        playerScript.equippedBottomStats[3] = 0;
        playerScript.equippedBottomStats[4] = 5;
        playerScript.equippedBottomStats[5] = 0;
        playerScript.equippedBottomStats[6] = 0;
        playerScript.equippedBottomStats[7] = 0;
        playerScript.equippedBottomStats[8] = 0;

        bottom3D.GetComponent<MeshRenderer>().material = green;
        bottom2D.GetComponent<SpriteRenderer>().sprite = greenBottom;
    }
}
