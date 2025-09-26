using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    [Header("Hook")]
    [SerializeField] private Transform _hook;
    [SerializeField] private Transform _crane;
    [SerializeField] private Transform _basePlatform;

    [Header("Speeds")]
    [SerializeField] private float _hookSpeed = 1f; // вверх/вниз
    [SerializeField] private float _craneSpeed = 1f; // восток/запад
    [SerializeField] private float _platformSpeed = 1f; // север/юг

    [Header("Limits")]
    [SerializeField] private Vector2 _hookYLimits = new Vector2(-3.8f, 1.7f);
    [SerializeField] private Vector2 _craneXLimits = new Vector2(-45f, 45f);
    [SerializeField] private Vector2 _platformZLimits = new Vector2(-9f, 9f);

    bool movingUp, movingDown,
         movingEast, movingWest,
         movingNorth, movingSouth;

    private void OnEnable()
    {
        if (CraneSignals.Instance != null)
        {
            CraneSignals.Instance.OnUp.AddListener(HandleUp);
            CraneSignals.Instance.OnDown.AddListener(HandleDown);
            CraneSignals.Instance.OnEast.AddListener(HandleEast);
            CraneSignals.Instance.OnWest.AddListener(HandleWest);
            CraneSignals.Instance.OnNorth.AddListener(HandleNorth);
            CraneSignals.Instance.OnSouth.AddListener(HandleSouth);
        }
    }

    private void OnDisable()
    {
        if (CraneSignals.Instance != null)
        {
            CraneSignals.Instance.OnUp.RemoveListener(HandleUp);
            CraneSignals.Instance.OnDown.RemoveListener(HandleDown);
            CraneSignals.Instance.OnEast.RemoveListener(HandleEast);
            CraneSignals.Instance.OnWest.RemoveListener(HandleWest);
            CraneSignals.Instance.OnNorth.RemoveListener(HandleNorth);
            CraneSignals.Instance.OnSouth.RemoveListener(HandleSouth);
        }
    }

    void HandleUp(bool v) => movingUp = v;
    void HandleDown(bool v) => movingDown = v;
    void HandleEast(bool v) => movingEast = v;
    void HandleWest(bool v) => movingWest = v;
    void HandleNorth(bool v) => movingNorth = v;
    void HandleSouth(bool v) => movingSouth = v;

    private void Update()
    {
        if (_hook == null || _crane == null || _basePlatform == null) return;

        if (movingUp && _hook.localPosition.y < _hookYLimits.y)
            _hook.Translate(Vector3.up * _hookSpeed * Time.deltaTime, Space.Self);
        if (movingDown && _hook.localPosition.y > _hookYLimits.x)
            _hook.Translate(Vector3.down * _hookSpeed * Time.deltaTime, Space.Self);

        if (movingEast && _crane.localPosition.x < _craneXLimits.y)
            _crane.Translate(Vector3.right * _craneSpeed * Time.deltaTime, Space.Self);
        if (movingWest && _crane.localPosition.x > _craneXLimits.x)
            _crane.Translate(Vector3.left * _craneSpeed * Time.deltaTime, Space.Self);

        if (movingNorth && _basePlatform.localPosition.z < _platformZLimits.y)
            _basePlatform.Translate(Vector3.forward * _platformSpeed * Time.deltaTime, Space.Self);
        if (movingSouth && _basePlatform.localPosition.z > _platformZLimits.x)
            _basePlatform.Translate(Vector3.back * _platformSpeed * Time.deltaTime, Space.Self);
    }
}
