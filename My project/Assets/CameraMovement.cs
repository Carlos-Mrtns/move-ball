using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform ball;
    public float speed = 3.0f;
    public float distance = 10.0f;
    public float height = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = speed * Time.fixedDeltaTime;
        Vector3 position = transform.position;

        position.x = Mathf.Lerp(transform.position.x, ball.position.x, time);
        position.y = Mathf.Lerp(transform.position.y + height, ball.position.y, time);
        position.z = Mathf.Lerp(transform.position.z - distance, ball.position.z, time);

        transform.position = position;
    }
}
