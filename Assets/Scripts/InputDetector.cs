using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    // Stores the button presses from the last frame
    bool left;
    bool mid;
    bool right;

    void Start()
    {
        
    }

    void Update()
    {
        // Detect the first frame a button is pressed
        if (Input.GetKey(KeyCode.A) && !left)
        {
            left = true;
            Debug.Log("Left");
        }
        if (Input.GetKey(KeyCode.W) && !mid)
        {
            mid = true;
            Debug.Log("Mid");
        }
        if (Input.GetKey(KeyCode.D) && !right)
        {
            right = true;
            Debug.Log("Right");
        }

        // Set vars
        left = Input.GetKey(KeyCode.A);
        mid = Input.GetKey(KeyCode.W);
        right = Input.GetKey(KeyCode.D);
    }
}
