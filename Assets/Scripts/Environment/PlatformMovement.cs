using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform[] waypoints;       // Durdurma noktalarýnýn transformlarý
    public float speed = 3f;            // Platform hýzý

    private int currentWaypointIndex = 0;   // Geçerli durdurma noktasý index'i
    private Transform currentWaypoint;      // Geçerli durdurma noktasýnýn transformu

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

        // Hedefe doðru ilerle
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

        // Hedefe ulaþýldýðýnda dur
        if (transform.position == currentWaypoint.position)
        {
            // Son durdurma noktasýna ulaþýldýðýnda dönüþ yap
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
