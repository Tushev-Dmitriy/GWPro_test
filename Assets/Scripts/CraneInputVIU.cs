using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneInputVIU : MonoBehaviour
{
    [SerializeField] private ButtonType _buttonType;
    
    private bool _isInside = false;

    private void OnTriggerStay(Collider other)
    {
        if (!other.name.Contains("GuideLine")) return;

        Debug.Log(1);
        bool triggerPressed = 
            ViveInput.GetPress(HandRole.RightHand, ControllerButton.Trigger) ||
            ViveInput.GetPress(HandRole.LeftHand, ControllerButton.Trigger);

        InvokeSignal(triggerPressed);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.name.Contains("GuideLine")) return;

        InvokeSignal(false);
    }

    private void InvokeSignal(bool isPressed)
    {
        switch (_buttonType)
        {
            case ButtonType.Up:
                CraneSignals.Instance.InvokeUp(isPressed);
                break;
            case ButtonType.Down:
                CraneSignals.Instance.InvokeDown(isPressed);
                break;
            case ButtonType.East:
                CraneSignals.Instance.InvokeEast(isPressed);
                break;
            case ButtonType.West:
                CraneSignals.Instance.InvokeWest(isPressed);
                break;
            case ButtonType.North:
                CraneSignals.Instance.InvokeNorth(isPressed);
                break;
            case ButtonType.South:
                CraneSignals.Instance.InvokeSouth(isPressed);
                break;
        }
    }
}
