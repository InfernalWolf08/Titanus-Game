using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EnemyEyes : MonoBehaviour
{
    public Transform target = null;
    public float maxDistance = 10f;
    [Range(0, 360f)] public float angle = 45f;
    public bool targetIsVisible { get; private set; }

    void Update()
    {
        targetIsVisible = CheckVisibility();
    }

    public bool CheckVisibilityToPoint(Vector3 worldPoint)
    {
        Vector3 directionToTarget = worldPoint - transform.position;
        float degreesToTarget = Vector3.Angle(transform.forward, directionToTarget);
        bool withinArc = degreesToTarget < (angle/2);

        if (!withinArc)
        {
            return false;
        }

        float distanceToTarget = directionToTarget.magnitude;

        float rayDistance = Mathf.Min(maxDistance, distanceToTarget);
        Ray ray = new Ray(transform.position, directionToTarget);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.transform == target)
            {
                return true;
            }

            return false;
        } else {
            return true;
        }
    }

    public bool CheckVisibility()
    {
        Vector3 directionToTarget = target.position - transform.position;
        float degreesToTarget = Vector3.Angle(transform.forward, directionToTarget);
        bool withinArc = degreesToTarget < (angle/2);

        if (!withinArc)
        {
            return false;
        }

        float distanceToTarget = directionToTarget.magnitude;

        float rayDistance = Mathf.Min(maxDistance, distanceToTarget);
        Ray ray = new Ray(transform.position, directionToTarget);
        RaycastHit hit;

        bool canSee = false;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.transform == target)
            {
                canSee = true;
            }

            Debug.DrawLine(transform.position, hit.point);
        } else {
            Debug.DrawRay(transform.position, directionToTarget.normalized*rayDistance);
        }

        print(canSee);
        return canSee;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(EnemyEyes))]
public class EnemyEyesEditor : Editor 
{
    private void OnSceneGUI()
    {
        var visibility = target as EnemyEyes;

        Handles.color = new Color(1, 1, 1, 0.1f);

        Vector3 forwardPointMinusHalfAngle = Quaternion.Euler(0, -visibility.angle/2, 0) * visibility.transform.forward;

        Vector3 arcStart = forwardPointMinusHalfAngle * visibility.maxDistance;

        Handles.DrawSolidArc(visibility.transform.position, Vector3.up, arcStart, visibility.angle, visibility.maxDistance);
        Handles.color = Color.white;

        Vector3 handlePosition = visibility.transform.position + visibility.transform.forward * visibility.maxDistance;
        visibility.maxDistance = Handles.ScaleValueHandle(visibility.maxDistance, handlePosition, visibility.transform.rotation, 1, Handles.ConeHandleCap, 0.25f);
    }
}
#endif