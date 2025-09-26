using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableRenderer : MonoBehaviour
{
    [SerializeField] private Transform _from;
    [SerializeField] private Transform _to;
    private LineRenderer _lr;

    void Awake() { _lr = GetComponent<LineRenderer>(); }

    void Update()
    {
        if (_from == null || _to == null) return;
        _lr.positionCount = 2;
        _lr.SetPosition(0, _from.position);
        _lr.SetPosition(1, _to.position);
    }
}
