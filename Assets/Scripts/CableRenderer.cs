using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableRenderer : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    private LineRenderer _line;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _line.positionCount = 2;
    }

    private void Update()
    {
        if (_startPoint == null || _endPoint == null) return;

        _line.SetPosition(0, _startPoint.position);
        _line.SetPosition(1, _endPoint.position);
    }
}
