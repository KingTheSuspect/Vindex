using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform[] waypoints;       // Durdurma noktalar�n�n transformlar�
    public float speed = 3f;            // Platform h�z�

    private int currentWaypointIndex = 0;   // Ge�erli durdurma noktas� index'i
    private Transform currentWaypoint;      // Ge�erli durdurma noktas�n�n transformu

    private void Start()
    {
        if (waypoints.Length > 0)
        {
            currentWaypoint = waypoints[currentWaypointIndex];
        }
        this.gameObject.transform.position = currentWaypoint.transform.position; 
        
    }

    private void FixedUpdate()
    {
        if (currentWaypoint == null)
            return;

        // Hedefe do�ru ilerle
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

        // Hedefe ula��ld���nda dur
        if (transform.position == currentWaypoint.position)
        {
            // Son durdurma noktas�na ula��ld���nda d�n�� yap
            if (currentWaypointIndex == waypoints.Length - 1)
            {
                currentWaypointIndex = 0;
            }
            else
            {
                currentWaypointIndex++;
            }

            currentWaypoint = waypoints[currentWaypointIndex];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
