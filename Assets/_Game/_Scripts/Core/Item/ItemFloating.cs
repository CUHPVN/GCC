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
    [SerializeField] private AnimationCurve inCurve;
    [SerializeField] private AnimationCurve outCurve;


    public void Floating()
    {
        if(floating!=null) StopCoroutine(floating);
        floating = StartCoroutine(Float(duration,visual.localScale,maxScale,inCurve));
    }
    public void UnFloating()
    {
        if(floating!=null) StopCoroutine(floating);
        floating = StartCoroutine(Float(duration,visual.localScale,minScale, outCurve));
    }
    private IEnumerator Float(float duration,Vector3 startScale, Vector3 targetScale,AnimationCurve curve)
    {
        float time = 0;
        while(time < duration)
        {
            time+= Time.deltaTime;
            visual.transform.localScale = Vector3.Lerp(startScale, targetScale, curve.Evaluate(time/(duration)));
            yield return null;
        }
        visual.transform.localScale = targetScale;

    }
    public void OnDestroy()
    {
        StopAllCoroutines();
    }
}