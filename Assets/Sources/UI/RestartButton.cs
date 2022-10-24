using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private void Start()
    {
        if (TryGetComponent(out Button button))
        {
            button.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
        }
    }
}
