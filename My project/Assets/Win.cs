using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Win : MonoBehaviour
{

    private Dictionary<string, GameObject> gameScreens = new Dictionary<string, GameObject>();
    public int level;

    void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out Ball ball);
        ball.canMove = false;
        ball.rb.velocity = Vector3.zero;
        ball.rb.angularVelocity = Vector3.zero;

        foreach (GameObject go in gameScreens.Values)
            go.SetActive(false);

        level++;

        if (SceneManager.sceneCount <= level)
            SceneManager.LoadScene(level);
    }
}

