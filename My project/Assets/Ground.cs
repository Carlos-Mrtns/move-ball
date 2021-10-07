using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Transform ball;
    private Vector3 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = ball.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = ball.position;
        position.y = transform.position.y;
        transform.position = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out Rigidbody rb);
        if (rb) StartCoroutine (Reset(rb));
    }

    private IEnumerator Reset (Rigidbody rb)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        yield return new WaitForFixedUpdate();

        rb.transform.position = startPoint;
        rb.transform.rotation = Quaternion.identity;
    }
}
