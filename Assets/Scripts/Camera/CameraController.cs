using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    public float minHeight, maxHeight;
    public float minXPos, maxXPos;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); ;
    }



    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(Mathf.Lerp(transform.position.x, target.position.x, 0.1f), minXPos, maxXPos), Mathf.Clamp(Mathf.Lerp(transform.position.y, target.position.y, 0.1f), minHeight, maxHeight), transform.position.z);
    }
}