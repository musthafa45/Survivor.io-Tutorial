using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    [SerializeField] private float playerSpeed = 10;
    private Vector3 playerLocalScale;
    private void Awake()
    {
        playerLocalScale = transform.localScale;
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 playerInputValue = InputManager.Instance.GetJoystickInput();
        HandleMovement(playerInputValue);
        HandleFaceRotation(playerInputValue);
    }

    private void HandleFaceRotation(Vector2 playerInputValue)
    {
        if(playerInputValue.x < 0)
        {
            // Player Looking left
            transform.localScale = new Vector3(-playerLocalScale.x,transform.localScale.y,transform.localScale.z) ;
        }
        else if(playerInputValue.x > 0)
        {
            // player Looking right.
            transform.localScale = new Vector3(playerLocalScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void HandleMovement(Vector2 playerInputValue)
    {
        rigidBody2D.velocity = playerInputValue * playerSpeed * 10 * Time.fixedDeltaTime;
    }

    public bool IsWalking(){
        return rigidBody2D.velocity != Vector2.zero;
    }
}
