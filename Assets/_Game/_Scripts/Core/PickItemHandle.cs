using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemHandle : MonoBehaviour, IUpdateable
{
    [SerializeField] private LayerMask pickableLayer;
    [SerializeField] private IPickable pickableObj;

    private void OnEnable()
    {
        UpdateManager.Register(this);
    }
    private void OnDisable()
    {
        UpdateManager.UnRegister(this);
    }
    public void OnUpdate()
    {
        CheckClickItem();
        CheckDropItem();
    }
    private void CheckClickItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(InputManager.Instance.MousePos, Vector3.zero, Mathf.Infinity, pickableLayer);
            if(hit.collider != null)
            {
                pickableObj = hit.collider.GetComponent<IPickable>();
                if(pickableObj!=null) pickableObj.IsPicked();
            }
        }
    }
    private void CheckDropItem()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (pickableObj == null) return;
            pickableObj.UnPicked();
            pickableObj = null;
        }
    }
}
