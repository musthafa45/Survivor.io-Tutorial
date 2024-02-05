using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField] private Transform playerTransform = null;
   [SerializeField] private float offsetX;
   [SerializeField] private float offsetY;
    private Camera camera;
   [SerializeField] private float moveSpeed = 10;

   private void Awake() {
    camera = Camera.main;
   }
   
   private void Update() {
    transform.position = Vector3.Lerp(transform.position, new Vector3(
        Mathf.Clamp(playerTransform.position.x + offsetX,-12f,12f),
        Mathf.Clamp(playerTransform.position.y + offsetY,-12.5f,12.5f),
    camera.transform.position.z),moveSpeed * Time.deltaTime);
   }
}
