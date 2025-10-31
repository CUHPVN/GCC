using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemFloating))]
public class Item : MonoBehaviour, IPickable, IUpdateable
{
    [SerializeField] private ItemFloating itemFloating;
    [SerializeField] private ItemData _data;
    private Vector2Int currentSlot = -Vector2Int.one;
    private Vector2 lastPos;
    private Vector2 offset;

    private bool picked=false;
    private bool canClick = true;
   
    void Awake()
    {
        if(_data == null) _data = new ItemData();
        lastPos = transform.position;
        itemFloating = GetComponent<ItemFloating>();
    }
    private void OnEnable()
    {
        UpdateManager.Register(this);
    }
    private void OnDisable()
    {
        UpdateManager.UnRegister(this);
    }
    public void IsPicked()
    {
        if (!canClick) return;
        picked = true;
        canClick = false;
        lastPos = transform.position;
        offset = InputManager.Instance.MousePos - lastPos;
        itemFloating.Floating();
    }

    public void OnPicked()
    {
        transform.position = InputManager.Instance.MousePos - offset; 
    }

    public void UnPicked()
    {
        if (!picked) return;
        picked = false;
        canClick = true;
        GridManager.Instance.OnItemUpPicked(_data,ref lastPos,transform,ref currentSlot,this);
        itemFloating.UnFloating();
    }
    public void MoveTo(Vector3 target)
    {
        canClick = false;
        StartCoroutine(Move(target, 0.1f));
    }
    private IEnumerator Move(Vector3 target, float duration)
    {
        float time = 0;
        Vector3 startPos = transform.position;
        while (time < duration)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, target, time / duration);
            yield return null;
        }
        transform.position = target;
        canClick = true;
        yield break;
    }
    public void OnUpdate()
    {
        CheckPicked();
    }
    private void CheckPicked()
    {
        if (!picked) return;
        OnPicked();
    }
    private void OnDestroy()
    {
        StopAllCoroutines(); 
    }

   
}
