using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouroutineTheory : MonoBehaviour
{
    
    IEnumerable DelayForSeconds(float seconds)
    {
        yield return new WaitUntil(()=> true);
        yield return null;
    }
}
