using UnityEngine;

public class FloatObject : MonoBehaviour
{
    public float speed = 1f;
    public float height = 0.02f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time * speed) * height, 0);
    }
}