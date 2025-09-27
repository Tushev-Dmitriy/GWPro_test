using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GasAnalyzerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ButtonHold _powerButton;
    [SerializeField] private TextMeshProUGUI _displayText;
    [SerializeField] private Image _displayBackground;
    [SerializeField] private Transform _probeTransform;

    [Header("Settings")]
    [SerializeField] private string _dangerTag = "DangerZone";

    private bool _isOn = false;

    private void Start()
    {
        if (_powerButton != null)
        {
            _powerButton.OnHoldComplete.AddListener(TogglePower);
            _powerButton.OnHoldProgress.AddListener(UpdateHoldProgress);
        }

        if (_displayText != null) _displayText.gameObject.SetActive(false);
        if (_displayBackground != null) _displayBackground.enabled = false;
    }

    private void Update()
    {
        if (_isOn)
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

        float minDist = float.MaxValue;
        foreach (var zone in zones)
        {
            float dist = Vector3.Distance(_probeTransform.position, zone.transform.position);
            if (dist < minDist) minDist = dist;
        }

        _displayText.text = minDist.ToString("F2") + " m";
    }

    private void TogglePower()
    {
        _isOn = !_isOn;

        if (_displayText != null) _displayText.gameObject.SetActive(_isOn);
        if (_displayBackground != null) _displayBackground.enabled = _isOn;

        if (!_isOn && _displayText != null)
            _displayText.text = "";
    }

    private void UpdateHoldProgress(float progress)
    {
        if (!_isOn && _displayBackground != null)
        {
            _displayBackground.enabled = true;
            _displayBackground.color = Color.Lerp(Color.red, Color.green, progress);
        }

        if (progress <= 0f && !_isOn && _displayBackground != null)
        {
            _displayBackground.enabled = false;
        }
    }
}
