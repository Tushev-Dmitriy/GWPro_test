using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private ButtonType _buttonType;
    private bool _isHolding = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isHolding = true;
        switch (_buttonType)
        {
            case ButtonType.Up:
                CraneSignals.Instance.InvokeUp(_isHolding);
                break;
            case ButtonType.Down:
                CraneSignals.Instance.InvokeDown(_isHolding);
                break;
            case ButtonType.East:
                CraneSignals.Instance.InvokeEast(_isHolding);
                break;
            case ButtonType.West:
                CraneSignals.Instance.InvokeWest(_isHolding);
                break;
            case ButtonType.North:
                CraneSignals.Instance.InvokeNorth(_isHolding);
                break;
            case ButtonType.South:
                CraneSignals.Instance.InvokeSouth(_isHolding);
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isHolding = false;
        switch (_buttonType)
        {
            case ButtonType.Up:
                CraneSignals.Instance.InvokeUp(_isHolding);
                break;
            case ButtonType.Down:
                CraneSignals.Instance.InvokeDown(_isHolding);
                break;
            case ButtonType.East:
                CraneSignals.Instance.InvokeEast(_isHolding);
                break;
            case ButtonType.West:
                CraneSignals.Instance.InvokeWest(_isHolding);
                break;
            case ButtonType.North:
                CraneSignals.Instance.InvokeNorth(_isHolding);
                break;
            case ButtonType.South:
                CraneSignals.Instance.InvokeSouth(_isHolding);
                break;
        }
    }
}
