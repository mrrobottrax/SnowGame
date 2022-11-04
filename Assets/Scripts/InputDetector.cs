using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    // Stores the button presses from the last frame
    bool left;
    bool mid;
    bool right;

    void Update()
    {
        // Detect the first frame a button is pressed
        if (Input.GetKey(KeyCode.A) && !left)
        {
            left = true;

            switch (GameManager.Singleton.gameState)
            {
                case GameManager.GameState.main:
                    GameManager.Singleton.leftEnemy.Hit();
                    break;

                case GameManager.GameState.startScreen:
                    GameManager.Singleton.StartGame();
                    break;
            }
        }
        if (Input.GetKey(KeyCode.W) && !mid)
        {
            mid = true;

            switch (GameManager.Singleton.gameState)
            {
                case GameManager.GameState.main:
                    GameManager.Singleton.midEnemy.Hit();
                    break;

                case GameManager.GameState.startScreen:
                    GameManager.Singleton.StartGame();
                    break;
            }
        }
        if (Input.GetKey(KeyCode.D) && !right)
        {
            right = true;

            switch (GameManager.Singleton.gameState)
            {
                case GameManager.GameState.main:
                    GameManager.Singleton.rightEnemy.Hit();
                    break;

                case GameManager.GameState.startScreen:
                    GameManager.Singleton.StartGame();
                    break;
            }
        }

        // Set vars
        left = Input.GetKey(KeyCode.A);
        mid = Input.GetKey(KeyCode.W);
        right = Input.GetKey(KeyCode.D);
    }
}
