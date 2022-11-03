using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialReader : MonoBehaviour
{
    [SerializeField] float maxDist = 30;

    SerialPort stream = new SerialPort("COM3", 9600); //Set the port and the baud rate (9600, is standard on most devices)

    int value;

    int[] distanceHistory = new int[200];
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        stream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        // While there are bytes to read
        if (stream.BytesToRead > 0)
        {
            // Read every byte available
            for (int i = 0; i < stream.BytesToRead; i++)
            {
                value = int.Parse(stream.ReadLine());
            }
        }

        distanceHistory[index] = value;
        index++;

        if (index >= distanceHistory.Length)
        {
            index = 0;
        }
    }

    private void FixedUpdate()
    {
        GameManager.Singleton.playerDucked = GetPlayerDucked();
    }

    bool GetPlayerDucked()
    {
        // Average distance history
        int sum = 0;

        for (int i = 0; i < distanceHistory.Length; i++)
        {
            sum += distanceHistory[i];
        }

        float avg = sum / distanceHistory.Length;

        //Debug.Log(avg);

        if (avg > maxDist)
        {
            return true;
        }

        return false;
    }
}
