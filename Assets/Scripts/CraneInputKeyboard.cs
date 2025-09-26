using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//тест для эдитора
public class CraneInputKeyboard : MonoBehaviour
{
    private void Update()
    {
        if (CraneSignals.Instance == null) return;

        CraneSignals.Instance.InvokeUp(Input.GetKey(KeyCode.Q));
        CraneSignals.Instance.InvokeDown(Input.GetKey(KeyCode.E));
        CraneSignals.Instance.InvokeNorth(Input.GetKey(KeyCode.W));
        CraneSignals.Instance.InvokeSouth(Input.GetKey(KeyCode.S));
        CraneSignals.Instance.InvokeEast(Input.GetKey(KeyCode.D));
        CraneSignals.Instance.InvokeWest(Input.GetKey(KeyCode.A));
    }
}
