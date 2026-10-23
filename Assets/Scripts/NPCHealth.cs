using UnityEngine;
using System;

public class NPCHealth : MonoBehaviour
{
    [SerializeField] private NPCStatsConfig statsConfig;

    // Приватное поле (изменяемое)
    private float currentHealth;

    // Публичное свойство только на чтение
    public float CurrentHealth => currentHealth;

    // Публичное свойство для чтения максимума из SO
    public float MaxHealth => statsConfig.MaxHealth;

    public event Action<float, float> OnHealthChanged;

    private void Start()
    {
        currentHealth = statsConfig.MaxHealth;
        OnHealthChanged?.Invoke(currentHealth, MaxHealth);
    }

    // Метод (бизнес-логика)
    public void DecreaseHealth(float damageAmount)
    {
        var finalDamage = Mathf.Max(0, damageAmount - statsConfig.Armor);
        currentHealth = Mathf.Max(0, currentHealth - finalDamage);

        OnHealthChanged?.Invoke(currentHealth, MaxHealth);
    }

    // Метод (бизнес-логика)
    public void IncreaseHealth(float healAmount)
    {
        currentHealth = Mathf.Min(MaxHealth, currentHealth + healAmount);

        OnHealthChanged?.Invoke(currentHealth, MaxHealth);
    }
}