using UnityEngine;

public class FloatObject : MonoBehaviour
{
    public float speed = 1f;
    public float height = 0.02f;
    public float rotateSpeed = 20f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}