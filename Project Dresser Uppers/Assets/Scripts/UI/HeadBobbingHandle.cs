using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class HeadBobbingHandle : MonoBehaviour
{
    public RectTransform headHandle;
    public float timer;
    public float originalYPosition;

    public Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponentInChildren<Player>();
        headHandle = GetComponent<RectTransform>();
        originalYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isFighting == true || playerScript.hasDied == true)
        {
            headHandle.offsetMin = new Vector2(headHandle.offsetMin.x, 0);
            headHandle.offsetMax = new Vector2(headHandle.offsetMax.x, 0);
        }

        if (playerScript.isFighting == false && playerScript.hasDied == false)
        {
            timer += Time.deltaTime;
        }

        if (timer > 0f && timer < 0.1f)
        {
            headHandle.offsetMin = new Vector2(headHandle.offsetMin.x, -2.0f);
            headHandle.offsetMax = new Vector2(headHandle.offsetMax.x, -2.0f);
        }

        if (timer > 0.5f && timer < 0.6f)
        {
            headHandle.offsetMin = new Vector2(headHandle.offsetMin.x, 2.0f);
            headHandle.offsetMax = new Vector2(headHandle.offsetMax.x, 2.0f);
        }

        if (timer >= 1.0f)
        {
            timer = 0;
        }

    }
}
