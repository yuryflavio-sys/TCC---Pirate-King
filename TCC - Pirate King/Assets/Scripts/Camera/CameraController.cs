using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f; 
    public Vector3 offset = new Vector3(0, 0, -10f);

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, offset.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}