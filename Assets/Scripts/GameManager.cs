using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    public bool playerDucked = false;

    AudioSource playerSounds;
    [SerializeField] AudioClip playerHit;
    [SerializeField] AudioClip duckMiss;

    [SerializeField] float duckDist = 1;
    [SerializeField] float duckSpeed = 2;
    float camOffset;

    Transform mainCamera;

    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;

        playerSounds = GetComponent<AudioSource>();

        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        if (playerDucked)
        {
            camOffset = Mathf.Lerp(camOffset, duckDist, duckSpeed * Time.deltaTime);
        }
        else
        {
            camOffset = Mathf.Lerp(camOffset, 0, duckSpeed * Time.deltaTime);
        }

        mainCamera.localPosition = new Vector3(0, -camOffset, 0);
    }

    public void PlayerHit()
    {
        Debug.Log("Hit!");
        playerSounds.PlayOneShot(playerHit);
    }

    public void DuckMiss()
    {
        Debug.Log("Duck!");
        playerSounds.PlayOneShot(duckMiss);

        AddScore(5);
    }

    public void AddScore(int add)
    {
        SetScore(score + add);
    }

    public void SetScore(int value)
    {
        score = value;
        scoreText.text = score.ToString();
    }
}
