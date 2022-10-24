using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private TMP_InputField _cooldownInputField;
    [SerializeField] private TMP_InputField _speedInputField;
    [SerializeField] private TMP_InputField _distanceInputField;
    [SerializeField] private Spawnable _spawnable;

    private float _cooldown;
    private float _speed;
    private float _targetDistance;
    private float _timeLeft;

    public event Action<float> OnTimeLeftChanged;

    private float TimeLeft
    {
        get { return _timeLeft; }

        set
        {
            _timeLeft = value;
            OnTimeLeftChanged?.Invoke(_timeLeft);
        }
    }

    private void Start()
    {
        if (!AreFieldsSet())
            return;

        _cooldown = float.Parse(_cooldownInputField.text, CultureInfo.InvariantCulture);
        _speed = float.Parse(_speedInputField.text, CultureInfo.InvariantCulture);
        _targetDistance = float.Parse(_distanceInputField.text, CultureInfo.InvariantCulture);

        _cooldownInputField.onValueChanged.AddListener((string value) => { _cooldown = float.Parse(value, CultureInfo.InvariantCulture); });
        _speedInputField.onValueChanged.AddListener((string value) => { _speed = float.Parse(value, CultureInfo.InvariantCulture); });
        _distanceInputField.onValueChanged.AddListener((string value) => { _targetDistance = float.Parse(value, CultureInfo.InvariantCulture); });

        TimeLeft = _cooldown;
    }

    private void Update()
    {
        if (!AreFieldsSet())
            return;

        TimeLeft -= Time.deltaTime;

        if (TimeLeft <= 0f)
        {
            ISpawnable spawnable = Instantiate(_spawnable, transform, false);
            spawnable.Init(_speed, _targetDistance);
            TimeLeft += _cooldown;
        }
    }

    private bool AreFieldsSet()
    {
        bool result = _cooldownInputField != null;
        result &= _speedInputField != null;
        result &= _distanceInputField != null;

        if (result == false)
            Debug.LogWarning("The fields are unset!");

        return result;
    }
}
