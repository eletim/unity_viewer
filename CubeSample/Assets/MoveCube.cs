using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
