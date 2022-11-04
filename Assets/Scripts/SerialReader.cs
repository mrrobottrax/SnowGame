using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialReader : MonoBehaviour
{
    [SerializeField] float maxDist = 30;

    SerialPort stream = new SerialPort("COM3", 9600); //Set the port and the baud rate (9600, is standard on most devices)

    int value;

    [SerializeField] float avgTime = 0.5f; // Time to average values over
    List<Distance> distanceHistory = new List<Distance>();

    struct Distance
    {
        public int dist;
        public float time;
    }

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

        distanceHistory.Add(new Distance
        {
            dist = value,
            time = Time.time
        });

        for (int i = distanceHistory.Count - 1; i >= 0; i--)
        {
            if (distanceHistory[i].time <= Time.time - avgTime)
            {
                distanceHistory.RemoveAt(i);
            }
        }
    }

    private void FixedUpdate()
    {
        GameManager.Singleton.playerDucked = GetPlayerDucked();

        // Override with space
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftControl))
        {
            GameManager.Singleton.playerDucked = true;
        }
    }

    bool GetPlayerDucked()
    {
        float val = GetMin();

        //Debug.Log(val);

        if (val > maxDist)
        {
            return true;
        }

        return false;
    }

    float GetAvg()
    {
        // Average distance history
        int sum = 0;

        int size = distanceHistory.Count;
        for (int i = 0; i < size; i++)
        {
            sum += distanceHistory[i].dist;
        }

        // Avoid divide by 0
        float avg;
        if (size != 0)
        {
            avg = sum / size;
        }
        else
        {
            avg = 0;
        }

        return avg;
    }

    int GetMin()
    {
        int size = distanceHistory.Count;

        if (size > 0)
        {
            int min = distanceHistory[0].dist;

            for (int i = 0; i < size; i++)
            {
                if (distanceHistory[i].dist < min)
                {
                    min = distanceHistory[i].dist;
                }
            }

            return min;
        }

        return 0;
    }
}
