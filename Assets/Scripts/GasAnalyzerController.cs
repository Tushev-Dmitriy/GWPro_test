using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GasAnalyzerController : MonoBehaviour
{
    [SerializeField] private ButtonHold _powerButton;
    [SerializeField] private TextMeshProUGUI _displayText;
    [SerializeField] private Transform _probeTransform;
    [SerializeField] private string _dangerTag = "DangerZone";


    private bool _isOn = false;

    private void Start()
    {
        if (_powerButton != null) _powerButton.OnHoldComplete.AddListener(TogglePower);
        if (_displayText != null) _displayText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!_isOn) return;
        UpdateDistance();
    }

    private void UpdateDistance()
    {
        if (_probeTransform == null || _displayText == null) return;

        var zones = GameObject.FindGameObjectsWithTag(_dangerTag);
        if (zones == null || zones.Length == 0)
        {
            _displayText.text = "No Danger Zone";
            return;
        }

        float min = float.MaxValue;
        foreach (var zone in zones)
        {
            float dist = Vector3.Distance(_probeTransform.position, zone.transform.position);
            if (dist < min) min = dist;
        }

        _displayText.text = min.ToString("F2") + " m";
    }

    private void TogglePower()
    {
        _isOn = !_isOn;
    }
}
