using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSpawner : MonoBehaviour
{
    [SerializeField] Transform spawner;
    [SerializeField] GameObject snowball;

    [SerializeField] float angle;

    public void ThrowSnowball()
    {
        Instantiate(snowball, spawner.position, Quaternion.AngleAxis(angle, Vector3.up));
    }
}
