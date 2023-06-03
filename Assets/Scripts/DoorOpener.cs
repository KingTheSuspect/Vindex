using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Transform[] waypoints;       // Durdurma noktalarýnýn transformlarý
    public float speed = 3f;            // Kapý hýzý
    private bool durum;

    private int currentWaypointIndex = 0;   // Geçerli durdurma noktasý index'i
    private Transform currentWaypoint;      // Geçerli durdurma noktasýnýn transformu

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

            // Hedefe doðru ilerle
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

            // Hedefe ulaþýldýðýnda dur
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
