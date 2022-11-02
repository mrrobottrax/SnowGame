using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Max and min times between attacks
    [SerializeField] float minTimeToAttack = 4;
    [SerializeField] float maxTimeToAttack = 4;

    // Additional time to recover after being hit
    [SerializeField] float recoverTime = 3;

    // Time until the next attack
    float timeToAttack;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

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
        SetAttackTime();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }
}
