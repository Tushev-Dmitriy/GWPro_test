using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneSignals : MonoBehaviour
{
    public static CraneSignals Instance { get; private set; }

    public BoolEvent OnUp = new BoolEvent();
    public BoolEvent OnDown = new BoolEvent();
    public BoolEvent OnEast = new BoolEvent();
    public BoolEvent OnWest = new BoolEvent();
    public BoolEvent OnNorth = new BoolEvent();
    public BoolEvent OnSouth = new BoolEvent();

    public event Action<bool> UpEvent;
    public event Action<bool> DownEvent;
    public event Action<bool> EastEvent;
    public event Action<bool> WestEvent;
    public event Action<bool> NorthEvent;
    public event Action<bool> SouthEvent;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void InvokeUp(bool val) { OnUp.Invoke(val); UpEvent?.Invoke(val); }
    public void InvokeDown(bool val) { OnDown.Invoke(val); DownEvent?.Invoke(val); }
    public void InvokeEast(bool val) { OnEast.Invoke(val); EastEvent?.Invoke(val); }
    public void InvokeWest(bool val) { OnWest.Invoke(val); WestEvent?.Invoke(val); }
    public void InvokeNorth(bool val) { OnNorth.Invoke(val); NorthEvent?.Invoke(val); }
    public void InvokeSouth(bool val) { OnSouth.Invoke(val); SouthEvent?.Invoke(val); }
}