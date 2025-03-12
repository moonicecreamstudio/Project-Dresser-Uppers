using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowMover : MonoBehaviour
{
    public AnimationCurve curve;
    public RectTransform window;
    public Vector2 startPosition;
    public Vector2 goalPosition;
    public float speed;
    private float current, target;

    // Start is called before the first frame update
    void Start()
    {
        window = GetComponent<RectTransform>();
        //var myValue = Mathf.Lerp(0, 10, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);

        window.anchoredPosition = Vector2.Lerp(startPosition, goalPosition, curve.Evaluate(current));
    }

    public void buttonPressed()
    {
        target = target == 0 ? 1 : 0;
    }
}
