using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    public Enemy leftEnemy;
    public Enemy midEnemy;
    public Enemy rightEnemy;

    public bool playerDucked = false;

    [SerializeField] GameObject[] lifeObjects;
    [SerializeField] int maxLives = 5;
    public int lives;

    // Player sounds
    AudioSource playerSounds;
    [SerializeField] AudioClip playerHit;
    [SerializeField] AudioClip duckMiss;

    // Music
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip mainTheme;
    [SerializeField] AudioClip menuTheme;
    [SerializeField] AudioClip loseMusic;

    [SerializeField] float duckDist = 1;
    [SerializeField] float duckSpeed = 2;
    float camOffset;

    Transform mainCamera;

    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;

    [SerializeField] ParticleSystem playerHitParticles;

    [SerializeField] Animator uiAnimator;

    public enum GameState
    {
        main,
        startScreen,
        gameOver,
    }

    public GameState gameState = GameState.startScreen;

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
        playerSounds.PlayOneShot(playerHit);
        playerHitParticles.Play();

        lives--;

        lifeObjects[lives].SetActive(false);

        if (lives <= 0)
        {
            EndGame();
        }
    }

    public void DuckMiss()
    {
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

    public void GoToMenu()
    {
        gameState = GameState.startScreen;

        musicSource.clip = menuTheme;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StartGame()
    {
        gameState = GameState.main;
        uiAnimator.SetTrigger("Start game");

        musicSource.clip = mainTheme;
        musicSource.loop = true;
        musicSource.Play();

        SetScore(0);
        lives = maxLives;

        leftEnemy.SetAttackTime();
        midEnemy.SetAttackTime();
        rightEnemy.SetAttackTime();

        for (int i = 0; i < lifeObjects.Length; i++)
        {
            lifeObjects[i].SetActive(true);
        }
    }

    public void EndGame()
    {
        gameState = GameState.gameOver;
        uiAnimator.SetTrigger("End game");

        musicSource.clip = loseMusic;
        musicSource.loop = false;
        musicSource.Play();
    }
}
