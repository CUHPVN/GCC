using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRange=1.5f;
    [SerializeField] private LayerMask attackableLayer;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Attack();
    }
    void Attack()
    {
        {
            //Attack 
            Collider2D[] raycastHit2D = Physics2D.OverlapCircleAll(transform.position, attackRange, attackableLayer);
            //danh nhung
            foreach (Collider2D collision in raycastHit2D)
            {
                if (collision.CompareTag("Player")) return;
                if (collision.CompareTag("NPC"))
                {
                    IAttackable attackable = collision.GetComponent<IAttackable>();
                    if (attackable != null)
                    {
                        attackable.OnAttacked(this.transform);
                    }
                }
            }
        }
    }
}
