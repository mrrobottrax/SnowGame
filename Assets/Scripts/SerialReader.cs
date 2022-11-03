using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialReader : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM3", 9600); //Set the port and the baud rate (9600, is standard on most devices)

    // Start is called before the first frame update
    void Start()
    {
        stream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        string value = stream.ReadLine(); //Read the information

        Debug.Log(value);
    }
}
