using System.Collections;
using TMPro;
using UnityEngine;


public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP_Health;
    private void Start()
    {
        EventManager.Instance.Subscribe<float>("TMP_UpdateHealth", UpdateHealth);
    }
    private void OnDestroy()
    {
        EventManager.Instance.Unsubscribe<float>("TMP_UpdateHealth", UpdateHealth);
    }
    private void UpdateHealth(float value)
    {
        TMP_Health?.SetText(value.ToString("F0"));
    }
}
