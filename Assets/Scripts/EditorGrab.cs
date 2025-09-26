using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorGrab : MonoBehaviour
{
    [SerializeField] private float _grabDistance = 3f;
    [SerializeField] private Transform _holdPoint;
    private Camera _cam;
    private Rigidbody _grabbedRb;
    private Transform _grabbedOriginalParent;
    private bool _isGrabbing;

    void Start()
    {
        _cam = Camera.main;
        if (_holdPoint == null)
        {
            _holdPoint = new GameObject("HoldPoint").transform;
            _holdPoint.SetParent(_cam.transform, false);
            _holdPoint.localPosition = new Vector3(0f, -0.1f, 1.2f);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryGrab();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Release();
        }

        if (_isGrabbing && _grabbedRb != null)
        {
            Vector3 targetPos = _holdPoint.position;
            _grabbedRb.MovePosition(Vector3.Lerp(_grabbedRb.position, targetPos, 20f * Time.deltaTime));
        }
    }

    void TryGrab()
    {
        Ray r = _cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out RaycastHit hit, 10f))
        {
            var rb = hit.collider.attachedRigidbody;
            if (rb != null)
            {
                _grabbedRb = rb;
                _grabbedOriginalParent = _grabbedRb.transform.parent;
                _grabbedRb.useGravity = false;
                _grabbedRb.constraints = RigidbodyConstraints.None;
                _isGrabbing = true;
            }
        }
    }

    void Release()
    {
        if (!_isGrabbing || _grabbedRb == null) return;
        _grabbedRb.useGravity = true;
        _isGrabbing = false;
        _grabbedRb = null;
    }
}
