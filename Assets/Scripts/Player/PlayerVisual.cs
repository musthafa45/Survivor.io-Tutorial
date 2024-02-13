using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;
    private HealthSystem healthSystem;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Start() {
        healthSystem.OnPlayerHealthFinished += PlayerHealthFinished;
    }
    private void OnDisable() {
        healthSystem.OnPlayerHealthFinished -= PlayerHealthFinished;
    }

    private void Update() {
        animator.SetBool("IsWalking",playerMovement.IsWalking());
    }

    private void PlayerHealthFinished()
    {
        animator.SetTrigger("Dead");
    }
}
