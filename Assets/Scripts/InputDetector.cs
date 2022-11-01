using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    // target vars
    bool left;
    bool mid;
    bool right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        left = Input.GetKey(KeyCode.A);
        mid = Input.GetKey(KeyCode.W);
        right = Input.GetKey(KeyCode.D);
    }
}
