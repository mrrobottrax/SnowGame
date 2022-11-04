using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Max and min times between attacks
    [SerializeField] float minTimeToAttack = 4;
    [SerializeField] float maxTimeToAttack = 4;

    // The time it takes to play the throw animation
    [SerializeField] float animationTime = 4;

    // Additional time to recover after being hit
    [SerializeField] float recoverTime = 3;

    // Time until the next attack
    float timeToAttack = 0;

    [SerializeField] Animator animator;
    [SerializeField] AudioSource source;

    // Sounds
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip popupSound;

    [SerializeField] ParticleSystem hitParticles;

    public void SetAttackTime()
    {
        timeToAttack = Random.Range(minTimeToAttack, maxTimeToAttack);
    }

    void UpdateTimer()
    {
        if (GameManager.Singleton.gameState == GameManager.GameState.main && timeToAttack <= 0)
        {
            Attack();
        }
        else if (timeToAttack > 0)
        {
            timeToAttack -= Time.deltaTime;
        }
    }

    void Attack()
    {
        animator.SetTrigger("Throw"); // Play throw animation
        //source.PlayOneShot(popupSound);

        SetAttackTime();
        timeToAttack += animationTime;
    }

    // Called when the player hits the enemy
    public void Hit()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Don't hit when the enemy is hiding
        if (stateInfo.IsName("Hide Idle"))
            return;

        animator.SetTrigger("Hit"); // Play hit animation
        hitParticles.Play(); // Particles
        source.PlayOneShot(hitSound); // Sound

        SetAttackTime();
        timeToAttack += recoverTime;

        GameManager.Singleton.AddScore(20);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }
}
