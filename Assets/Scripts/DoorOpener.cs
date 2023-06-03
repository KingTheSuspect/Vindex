using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Transform[] waypoints;       // Durdurma noktalar�n�n transformlar�
    public float speed = 3f;            // Kap� h�z�
    private bool durum;

    private int currentWaypointIndex = 0;   // Ge�erli durdurma noktas� index'i
    private Transform currentWaypoint;      // Ge�erli durdurma noktas�n�n transformu

    private void Start()
    {
        if (waypoints.Length > 0)
        {
            currentWaypoint = waypoints[currentWaypointIndex];
        }
        durum = false;

    }

    private void FixedUpdate()
    {
        if (durum)
        {
            if (currentWaypoint == null)
                return;

            // Hedefe do�ru ilerle
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

            // Hedefe ula��ld���nda dur
            if (transform.position == currentWaypoint.position)
            {
                currentWaypoint = waypoints[currentWaypointIndex];
            }
        }

    }
    public void OpenDoor()
    {
        durum = true;
    }
    public void CloseDoor()
    {
        durum = false;
    }
}
