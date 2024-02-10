using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        animator.SetBool("IsWalking",playerMovement.IsWalking());
    }
}
