using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private NPCHealth npcHealth;

    // Событие, на которое подпишется UI View
    public event Action<float, float> OnHealthUpdated;

    private void OnEnable()
    {
        if (npcHealth != null)
            npcHealth.OnHealthChanged += HandleHealthChanged;
    }

    private void OnDisable()
    {
        if (npcHealth != null)
            npcHealth.OnHealthChanged -= HandleHealthChanged;
    }

    private void HandleHealthChanged(float current, float max)
    {
        // Прокидываем событие дальше в UI
        OnHealthUpdated?.Invoke(current, max);
    }

    // Методы для UI Input
    public void DamageNPC(float amount) => npcHealth.DecreaseHealth(amount);
    public void HealNPC(float amount) => npcHealth.IncreaseHealth(amount);
}