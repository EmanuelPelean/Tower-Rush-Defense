using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem selfDestructParticlePrefab;
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;

    void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            var currentPos = transform.position;
            var t = 0f;
            while (t < 1)
            {
                t += Time.deltaTime / .5f;
                transform.position = Vector3.Lerp(currentPos, waypoint.transform.position, t);

                // rotate enemy to face forward direction
                Vector3 direction = waypoint.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                float step = 300f * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);

                yield return null;
            }

            //Vector3 waypointPosition = waypoint.transform.position;
            //transform.position = waypointPosition;
            //yield return new WaitForSeconds(movementPeriod);
        }
        SelfDestruct();
    }

    void SelfDestruct()
    {
        var vfx = Instantiate(selfDestructParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
