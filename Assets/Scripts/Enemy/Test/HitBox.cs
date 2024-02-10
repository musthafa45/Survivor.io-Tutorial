using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private float attackCircleRadius = 0.5f;
    [SerializeField] private LayerMask attackLayer;

    public void TryDoAttack()
    {
       Collider2D collider2D =  Physics2D.OverlapCircle(transform.position,attackCircleRadius,attackLayer);

       if(collider2D != null)
       {
          if(collider2D.gameObject.TryGetComponent(out PlayerMovement player))
          {
             Debug.Log("Player can Take Damage Now ");
          }
       }
    }
}
