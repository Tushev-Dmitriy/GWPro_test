using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonHold : MonoBehaviour
{
    [SerializeField] private float _requiredHold = 3f;
    public UnityEvent OnHoldComplete;
    public FloatEvent OnHoldProgress;

    private bool _isHolding;
    private float _holdStart;

    public void PressStart()
    {
        if (_isHolding) return;

        _isHolding = true;
        _holdStart = Time.time;
        StopAllCoroutines();
        StartCoroutine(HoldCoroutine());
    }

    public void PressEnd()
    {
        if (!_isHolding) return;
        
        _isHolding = false;
        StopAllCoroutines();
        OnHoldProgress.Invoke(0f);
    }

    IEnumerator HoldCoroutine()
    {
        while (_isHolding)
        {
            float heldTime = Time.time - _holdStart;
            float progress = Mathf.Clamp01(heldTime / _requiredHold);
            OnHoldProgress.Invoke(progress);
            if (heldTime >= _requiredHold)
            {
                _isHolding = false;
                OnHoldProgress.Invoke(1f);
                OnHoldComplete.Invoke();
                yield break;
            }
            yield return null;
        }
    }
}
