using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMover : MonoBehaviour
{
    public AnimationCurve curve;
    public Transform objectToMove;
    public Vector3 startPosition;
    public Vector3 goalPosition;
    public float speed;
    private float current, target;

    // Start is called before the first frame update
    void Start()
    {
        objectToMove = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);

        transform.position = Vector3.Lerp(startPosition, goalPosition, curve.Evaluate(current));
    }
    public void buttonPressed()
    {
        target = target == 0 ? 1 : 0;
    }

    public void buttonOn()
    {
        target = 1;
    }
    public void buttonOff()
    {
        target = 0;
    }
}
