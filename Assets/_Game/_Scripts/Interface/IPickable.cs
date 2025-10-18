using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable 
{
    void IsPicked();
    void OnPicked();
    void UnPicked();
}
