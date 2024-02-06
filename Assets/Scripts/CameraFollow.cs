using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Border Clamp Variables")]
    [SerializeField] private float leftEdge = -12f;
    [SerializeField] private float rightEdge = 12f;

    [SerializeField] private float upEdge = 12f;

    [SerializeField] private float downEdge = -12f;

    [SerializeField] private Transform playerTransform = null;

    [Header("Camera Offset Variables")]
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    private Camera mainCamera;
    [SerializeField] private float lerpSpeed = 1f;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(
            Mathf.Clamp(playerTransform.position.x + offsetX, leftEdge, rightEdge),
            Mathf.Clamp(playerTransform.position.y + offsetY, downEdge, upEdge),
            mainCamera.transform.position.z
        );

        // Apply lerp with the specified speed
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}
