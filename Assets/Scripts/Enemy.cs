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
    float timeToAttack;

    [SerializeField] Animator animator;
    [SerializeField] AudioSource source;

    // Sounds
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip popupSound;

    // Start is called before the first frame update
    void Start()
    {
        SetAttackTime();
    }

    void SetAttackTime()
    {
        timeToAttack = Random.Range(minTimeToAttack, maxTimeToAttack);
    }

    void UpdateTimer()
    {
        timeToAttack -= Time.deltaTime;

        if (timeToAttack <= 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Throw"); // Play throw animation
        source.PlayOneShot(popupSound);

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
        source.PlayOneShot(hitSound);
        SetAttackTime();
        timeToAttack += recoverTime;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }
}
