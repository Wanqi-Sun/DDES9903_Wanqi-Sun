using UnityEngine;

public class FloatingHint : MonoBehaviour
{
    public float floatSpeed = 1f;   // 上下漂浮的速度
    public float floatHeight = 0.2f; // 上下移动的幅度

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = startPos + new Vector3(0, newY, 0);
    }
}
