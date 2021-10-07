using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out Ball ball);
        ball.canMove = false;
        ball.rb.velocity = Vector3.zero;
        ball.rb.angularVelocity = Vector3.zero;

        Debug.Log("GANHOU !!!");
    }
}
