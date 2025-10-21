using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, ITriggerable, IAttackable
{
    [SerializeField] private Transform chatBox;
    private Rigidbody2D rb;
    [SerializeField] private CircleCollider2D circleCollider; 
    private bool isChat=false;
    private bool attackable = false; //co the danh
    [SerializeField] private float punchForce = 15f;

    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    public void OnTrigger()
    {
        SaySomeThing(); 
    }

    public void OnAttacked(Transform attacker)
    {
        Punch(attacker);
    }
    void Update()
    {
        
    }
    void Punch(Transform attacker)
    {
        if (!attackable) return; // chua duoc danh ko danh
        circleCollider.isTrigger = false; // khi danh thi bat collider de cho vui :)
        Vector3 direct = transform.position - attacker.position;
        direct.Normalize();
        rb.AddForce(direct*punchForce, ForceMode2D.Impulse); // Day Nguoc Lai
        
    }
    void SaySomeThing()
    {
        if (isChat) return; // Chat roi thi khong duoc chat nua :(
        isChat = true;
        chatBox.gameObject.SetActive(true);
        StartCoroutine(TurnOffChatBox());
    }
    private IEnumerator TurnOffChatBox()
    {
        yield return new WaitForSeconds(3f);
        chatBox.gameObject.SetActive(false);
        attackable = true;  // co the danh
        yield break;
    }

    
}
