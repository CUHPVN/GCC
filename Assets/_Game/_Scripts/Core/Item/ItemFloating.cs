using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloating : MonoBehaviour
{
    [SerializeField] private Transform visual;
    [SerializeField] private float duration = 0.15f;
    private Vector3 minScale = Vector3.one;
    private Vector3 maxScale = new Vector3(1.2f, 1.2f, 1.2f);

    private Coroutine floating;
    private Coroutine unfloating;
    [SerializeField] private AnimationCurve animationCurve;

    public void Floating()
    {
        if(unfloating!=null) StopCoroutine(unfloating);
        floating = StartCoroutine(Float(duration,visual.localScale,maxScale));
    }
    public void UnFloating()
    {
        if(floating!=null) StopCoroutine(floating);
        unfloating = StartCoroutine(Float(duration,visual.localScale,minScale));
    }
    private IEnumerator Float(float duration,Vector3 startScale, Vector3 targetScale)
    {
        float time = 0;
        while(true)
        {
            time+= Time.deltaTime;
            if (time >= duration)
            {
                visual.transform.localScale = targetScale;
                break;
            }
            visual.transform.localScale = Vector3.Lerp(startScale, targetScale, animationCurve.Evaluate(time/(duration)));
            yield return null;
        }
    }
    public void OnDestroy()
    {
        StopAllCoroutines();
    }
}