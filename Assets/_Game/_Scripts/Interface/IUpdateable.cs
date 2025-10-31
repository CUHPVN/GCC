using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Must be register in UpdateManager
/// </summary>
public interface IUpdateable
{
    public void OnUpdate();
}
