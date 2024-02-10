using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour
{
    public event Action OnEnemyAttackPerformed;
   public enum EnemyState
   {
    Idle,
    Chase,
    Attack,
    Dead
   }

   [SerializeField] protected EnemyState enemyState;
   [SerializeField] protected float attackRange = 0.3f;
   [SerializeField] protected float moveSpeed = 50;
   [SerializeField] protected float attackDelay = 0.5f;
   private float attackTimer;

   private Transform playerTransform = null;
   private Rigidbody2D rb;
   private SpriteRenderer spriteRenderer;

   private void Awake() {
    playerTransform = FindObjectOfType<PlayerMovement>().transform;
    rb = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    attackTimer = attackDelay;
   }
   private void FixedUpdate() {
    switch(enemyState)
    {
        case EnemyState.Idle:
        HandleIdleState();
        break;

        case EnemyState.Chase:
        HandleChaseState();
        break;

        case EnemyState.Attack:
        HandleAttackState();
        break;

        case EnemyState.Dead:
        HandleDeadState();
        break;
    }
   }

   private void Update() {
     transform.localScale = playerTransform.position.x < transform.position.x ? new Vector3(-1,1,1) : new Vector3(1,1,1);
     spriteRenderer.sortingOrder = playerTransform.position.y < transform.position.y ? -1 : 1;
   }

   protected virtual void HandleIdleState()
   {
     //Debug.Log(" Im on Idle");
   }

   protected virtual void HandleChaseState()
   {
     //Debug.Log(" Im on Chase");
     if(playerTransform != null)
     {
        Vector2 direction = playerTransform.position - transform.position;

        if(direction.magnitude > attackRange)
        {
            rb.velocity = direction.normalized * moveSpeed * Time.deltaTime;
        }
        else{
            SetState(EnemyState.Attack);
        }
     }
     else{
        Debug.LogError("Player Tr + Null");
     }
   }

   protected virtual void HandleAttackState()
   {
     //Debug.Log(" Im on Attack");
     Vector2 direction = playerTransform.position - transform.position;
     if(attackRange > direction.magnitude)
     {
        rb.velocity = Vector2.zero;
        
        attackTimer += Time.deltaTime;
        if(attackTimer > attackDelay)
        {
            attackTimer = 0f;
            OnEnemyAttackPerformed?.Invoke();
            //Debug.Attack
        }
     }
     else{
        SetState(EnemyState.Chase);
     }
   }

   protected virtual void HandleDeadState()
   {
     //Debug.Log(" Im on Dead");
    
   }

   public void SetState(EnemyState newState)
   {
     enemyState = newState;
   }

   public bool IsWalking()
   {
    return rb.velocity != Vector2.zero;
   }
}
