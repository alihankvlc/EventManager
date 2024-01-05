using System.Collections;
using UnityEngine;

public class CharacterManager : MonoBehaviour, IDamageable
{
    [SerializeField] private float m_Health;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            TakeDamage(10f);
    }
    public void TakeDamage(float amount)
    {
        m_Health = Mathf.Max(0, m_Health - amount);
        EventManager.Instance.TriggerEvent("TMP_UpdateHealth", m_Health);
    }
}