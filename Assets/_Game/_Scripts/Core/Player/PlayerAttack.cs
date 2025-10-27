using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRange=1.5f;
    [SerializeField] private LayerMask attackableLayer;
    Collider2D[] raycastHit2D = new Collider2D[10];


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Attack();
    }
    void Attack()
    {
        {
            //Attack 
            //Collider2D[] raycastHit2D = Physics2D.OverlapCircleAll(transform.position, attackRange, attackableLayer);
            int count = Physics2D.OverlapCircleNonAlloc(transform.position, attackRange, raycastHit2D,attackableLayer);
            //danh nhung
            for (int i= 0;i < count;i++)
            {
                if (raycastHit2D[i].CompareTag(CONST.TAG_PLAYER)) return;
                if (raycastHit2D[i].CompareTag(CONST.TAG_NPC))
                {
                    IAttackable attackable = raycastHit2D[i].GetComponent<IAttackable>();
                    if (attackable != null)
                    {
                        attackable.OnAttacked(this.transform);
                    }
                }
            }
        }
    }
}
