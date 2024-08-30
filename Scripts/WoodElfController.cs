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

    void Update()
    {
        // choose a new point to go to
        if (remainingDistance<=3)
        {
            if (Array.IndexOf(idleDestinations, curDest)+1<=idleDestinations.Length-1)
            {
                curDest = idleDestinations[Array.IndexOf(idleDestinations, curDest)+1];
            } else {
                curDest = idleDestinations[0];
            }

            agent.SetDestination(curDest.position);
        }
    }
}