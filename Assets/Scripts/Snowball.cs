using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public float speed = 1;

    public void TestHit()
    {
        // Don't do anything when in menus
        if (GameManager.Singleton.gameState != GameManager.GameState.main)
        {
            return;
        }

        if (!GameManager.Singleton.playerDucked)
        {
            GameManager.Singleton.PlayerHit();
        }
        else
        {
            GameManager.Singleton.DuckMiss();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
