using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    // Stores the button presses from the last frame
    bool left;
    bool mid;
    bool right;

    [SerializeField] GameObject leftGo;
    [SerializeField] GameObject midGo;
    [SerializeField] GameObject rightGo;

    [SerializeField] Enemy leftEnemy;
    [SerializeField] Enemy midEnemy;
    [SerializeField] Enemy rightEnemy;

    float leftTimer = 0;
    float midTimer = 0;
    float rightTimer = 0;

    int hits = 0;

    void Update()
    {
        /*
        if (leftTimer <= 0)
        {
            leftGo.SetActive(false);
        }
        else
        {
            leftTimer -= Time.deltaTime;
            leftGo.SetActive(true);
        }

        if (midTimer <= 0)
        {
            midGo.SetActive(false);
        }
        else
        {
            midTimer -= Time.deltaTime;
            midGo.SetActive(true);
        }

        if (rightTimer <= 0)
        {
            rightGo.SetActive(false);
        }
        else
        {
            rightTimer -= Time.deltaTime;
            rightGo.SetActive(true);
        }
        */

        // Detect the first frame a button is pressed
        if (Input.GetKey(KeyCode.A) && !left)
        {
            left = true;
            leftTimer = 1;
            leftEnemy.Hit();

            hits++;
            Debug.Log(hits);
        }
        if (Input.GetKey(KeyCode.W) && !mid)
        {
            mid = true;
            midTimer = 1;
            midEnemy.Hit();

            hits++;
            Debug.Log(hits);
        }
        if (Input.GetKey(KeyCode.D) && !right)
        {
            right = true;
            rightTimer = 1;
            rightEnemy.Hit();

            hits++;
            Debug.Log(hits);
        }

        // Set vars
        left = Input.GetKey(KeyCode.A);
        mid = Input.GetKey(KeyCode.W);
        right = Input.GetKey(KeyCode.D);
    }
}
