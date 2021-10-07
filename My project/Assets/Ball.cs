using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;

    bool jumping;
    public bool canMove {get; set;} = true;

    public float speed = 2.0f;
    public float jumpForce = 3.0f;
    float vertical = 0;
    float horizontal = 0;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (!canMove) return;

        rb.AddForce(0, 0, speed * vertical, ForceMode.Force);
        rb.AddForce(speed * horizontal, 0, 0, ForceMode.Force);

        if (Input.GetKey(KeyCode.Space) && !jumping)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        jumping = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        jumping = true;
    }
}
