using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WoodElfController : MonoBehaviour
{
    [Header("Animation")]
    public Animator animator;

    [Header("AI")]
    public NavMeshAgent agent;
    public Transform player;
    public bool agro;
    public Transform[] idleDestinations;
    public Transform curDest;
    public EnemyEyes sight;

    void Start()
    {
        // Initialize
    }

    void Update()
    {
        // chase player
        agro = sight.targetIsVisible;
        
        if (agro)
        {
            Chase();
        } else {
            Wander();
        }
    }

    void Wander()
    {
        // Play correct animation
        animator.SetBool("Walking", true);
        animator.SetBool("Chasing", false);
        animator.SetBool("Attacking", false);

        // choose a new point to go to
        if (agent.remainingDistance<=3)
        {
            if (Array.IndexOf(idleDestinations, curDest)+1<=idleDestinations.Length-1)
            {
                curDest = idleDestinations[Array.IndexOf(idleDestinations, curDest)+1];
            } else {
                curDest = idleDestinations[0];
            }

            // agent.SetDestination(curDest.position);
        }
    }

    void Chase()
    {
        // Play correct animation
        animator.SetBool("Walking", false);
        animator.SetBool("Chasing", true);
        animator.SetBool("Attacking", false);

        print(agent.remainingDistance);
        if (agent.remainingDistance>=0.5f)
        {
            // Go after player
            agent.SetDestination(player.position);
        } else {
            Attack();
        }
    }

    void Attack()
    {
        // Stop moving
        agent.ResetPath();

        // Play correct animation
        animator.SetBool("Walking", false);
        animator.SetBool("Chasing", false);
        animator.SetBool("Attacking", true);
    }
}