using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCStats", menuName = "Survival/NPC Stats Config")]
public class NPCStatsConfig : ScriptableObject
{
    [Header("Базовые статы (Неизменяемые в реальном времени)")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float armor = 5f;

    // Свойства для чтения (инкапсуляция)
    public float MaxHealth => maxHealth;
    public float Armor => armor;

    // Методы изменения базовых значений 
    public void IncreaseMaxHealth(float amount) => maxHealth += amount;
    public void DecreaseMaxHealth(float amount) => maxHealth = Mathf.Max(1f, maxHealth - amount);

    public void IncreaseArmor(float amount) => armor += amount;
    public void DecreaseArmor(float amount) => armor = Mathf.Max(0f, armor - amount);
}