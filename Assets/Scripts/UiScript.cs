using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScript : MonoBehaviour
{
    public void SetMenu()
    {
        GameManager.Singleton.GoToMenu();
    }
}
