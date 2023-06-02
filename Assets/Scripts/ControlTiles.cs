using UnityEngine;

public class ControlTiles : MonoBehaviour
{
    public LayerMask selectableLayer;           // The layer mask for selectable game objects
    public LineRenderer lineRenderer;           // Reference to the LineRenderer component
    public float maxPullDistance = 2f;           // Maximum distance to allow pulling an object

    private Camera mainCamera;                  // Reference to the main camera
    private GameObject selectedObject;          // Reference to the currently selected object
    private bool isDragging = false;             // Flag to check if an object is being dragged
    private Collider2D playerCollider;           // Collider of the player object

    private void Start()
    {
        mainCamera = Camera.main;
        lineRenderer.enabled = false; // Disable line renderer by default
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        // Check if the player clicks the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, selectableLayer);

            // Check if the ray hits a selectable object and the player is close enough to it
            if (hit.collider != null && Vector2.Distance(transform.position, hit.collider.transform.position) <= maxPullDistance)
            {
                selectedObject = hit.collider.gameObject;
                isDragging = true;
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, selectedObject.transform.position);
                selectedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<PlayerController>().moveSpeed = 0;
                GetComponent<PlayerController>().safeJump = false;
            }
        }

        // Check if the player releases the mouse button
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            GetComponent<PlayerController>().safeJump = true;
            GetComponent<PlayerController>().moveSpeed = 5;
            //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            selectedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            selectedObject = null;
            isDragging = false;
            lineRenderer.enabled = false;
        }

        // Move the selected object with the mouse
        if (isDragging)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Calculate the distance between the player and the mouse position
            float distanceToMouse = Vector2.Distance(transform.position, mousePosition);

            // Clamp the distance to the maximum pull distance
            if (distanceToMouse > maxPullDistance)
            {
                Vector3 direction = mousePosition - transform.position;
                direction = direction.normalized;
                mousePosition = transform.position + direction * maxPullDistance;
            }

            // Check for collision between player collider and other colliders in the scene
            Collider2D[] colliders = Physics2D.OverlapBoxAll(mousePosition, selectedObject.transform.localScale, 0f);
            bool hasCollision = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider != playerCollider)
                {
                    hasCollision = true;
                    break;
                }
            }

            // Move the selected object only if there is no collision
            if (!hasCollision)
            {
                selectedObject.transform.position = mousePosition;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, selectedObject.transform.position);
            }
        }
    }
}
