using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    private static List<IUpdateable> updateables = new();
    private static List<IUpdateable> pendingUpdateables = new();

    private static List<IStopUpdate> stopUpdates = new();
    private static List<IStopUpdate> pendingStopUpdate = new();

    public static void Register(IUpdateable updateable)
    {
        pendingUpdateables.Add(updateable);
    }
    public static void UnRegister(IUpdateable updateable)
    {
        updateables.Remove(updateable);
    }
    public static void RegisterStopUpdate(IStopUpdate stopUpdate)
    {
          pendingStopUpdate.Add(stopUpdate);
    }
    public static void UnRegisterStopUpdate(IStopUpdate stopUpdate)
    {
         stopUpdates.Remove(stopUpdate);
    }

    void Update()
    {
        if (GameManager.IsState(GameState.Pause))
        {
            for(int i = stopUpdates.Count - 1; i >= 0; i--) 
            {
                stopUpdates[i].OnStopUpdate();
            }
            stopUpdates.AddRange(pendingStopUpdate);
            pendingStopUpdate.Clear();
        }
        else
        if (GameManager.IsState(GameState.Play))
        {
            for (int i = updateables.Count - 1; i >= 0; i--)
            {
                updateables[i].OnUpdate();
            }
            updateables.AddRange(pendingUpdateables);
            pendingUpdateables.Clear();
        }
        
    }
}
