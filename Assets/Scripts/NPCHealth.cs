using UnityEngine;
using System;

public class NPCHealth : MonoBehaviour
{
    [SerializeField] private NPCStatsConfig statsConfig;

    // Приватные поля (изменяемые локально для этого конкретного NPC)
    private float currentHealth;
    private float currentMaxHealth;
    private float currentArmor;

    // Публичное свойство только на чтение
    public float CurrentHealth => currentHealth;

    // Публичные свойства для чтения локальных копий
    public float MaxHealth => currentMaxHealth;
    public float Armor => currentArmor;

    public event Action<float, float> OnHealthChanged;

    private void Start()
    {
        // При старте копируем базовые значения из ScriptableObject
        // Теперь каждый NPC хранит свои собственные копии
        currentMaxHealth = statsConfig.MaxHealth;
        currentArmor = statsConfig.Armor;

        currentHealth = currentMaxHealth;
        OnHealthChanged?.Invoke(currentHealth, MaxHealth);
    }

    // Метод (бизнес-логика)
    public void DecreaseHealth(float damageAmount)
    {
        // Считаем урон, используя локальную копию брони (currentArmor)
        var finalDamage = Mathf.Max(0, damageAmount - currentArmor);
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