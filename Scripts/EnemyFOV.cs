using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;
    public bool canSee;

    public LayerMask targetPlayer;

    public GameObject player;

    void Update()
    {
        Vector3 playerTarget = (player.transform.position - transform.position).normalized;

        if (Vector3.Angle(transform.forward, playerTarget) < viewAngle/2)
        {
            float distanceToTarget = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToTarget <= viewRadius)
            {
                if (Physics.Raycast(transform.position, playerTarget, distanceToTarget, targetPlayer))
                {
                    canSee = true;
                } else {
                    canSee = false;
                }
            } else {
                canSee = false;
            }
        } else {
            canSee = false;
        }
    }
}