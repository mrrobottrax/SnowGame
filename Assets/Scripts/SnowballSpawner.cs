using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSpawner : MonoBehaviour
{
    [SerializeField] Transform spawner;
    [SerializeField] GameObject snowball;

    public void ThrowSnowball()
    {
        Instantiate(snowball, spawner);
    }
}
