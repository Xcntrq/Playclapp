using TMPro;
using UnityEngine;

public class TimeLeftText : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        TryGetComponent(out _textMeshPro);

        if (_spawner != null)
            _spawner.OnTimeLeftChanged += Spawner_OnTimeLeftChanged;
    }

    private void OnDestroy()
    {
        if (_spawner != null)
            _spawner.OnTimeLeftChanged -= Spawner_OnTimeLeftChanged;
    }

    private void Spawner_OnTimeLeftChanged(float value)
    {
        if (_textMeshPro != null)
            _textMeshPro.SetText(value.ToString("n2"));
    }
}
