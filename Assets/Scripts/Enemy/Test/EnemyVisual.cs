using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    private Animator animator;
    private Enemy enemy;

    private void Start() {
        enemy.OnEnemyAttackPerformed += DoAttack;
    }
    private void OnDisable() {
        enemy.OnEnemyAttackPerformed -= DoAttack;
    }
   private void Awake() {
    animator = GetComponentInChildren<Animator>();
    enemy = GetComponent<Enemy>();
   }

    private void Update() {
        animator.SetBool("IsWalking",enemy.IsWalking());
    }

    private void DoAttack()
    {
        animator.SetTrigger("Attack");
    }
}
