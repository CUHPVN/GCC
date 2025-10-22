using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloating : MonoBehaviour
{
    [SerializeField] Transform visual;
    Coroutine floating;
    Coroutine unfloating;

    public void Floating()
    {
        if(unfloating!=null) StopCoroutine(unfloating);
        floating = StartCoroutine(Float(0.15f));
    }
    public void UnFloating()
    {
        if(floating!=null) StopCoroutine(floating);
        unfloating = StartCoroutine(UnFloat(0.15f));
    }
    private IEnumerator Float(float duration)
    {
        float time = 0;
        Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f);
        while(true)
        {
            time+= Time.deltaTime;
            if (time >= duration)
            {
                visual.transform.localScale = targetScale;
                break;
            }
            visual.transform.localScale = Vector3.Lerp(Vector3.one, targetScale, time/duration);
            yield return null;
        }
        yield break;
    }
    private IEnumerator UnFloat(float duration)
    {
        float time = 0;
        Vector3 targetScale = visual.transform.localScale;
        while (true)
        {
            time += Time.deltaTime;
            if (time >= duration)
            {
                visual.transform.localScale = Vector3.one;
                break;
            }
            visual.transform.localScale = Vector3.Lerp(targetScale, Vector3.one, time / duration);
            yield return null;
        }
        yield break;
    }
    public void OnDestroy()
    {
        StopAllCoroutines();
    }
}