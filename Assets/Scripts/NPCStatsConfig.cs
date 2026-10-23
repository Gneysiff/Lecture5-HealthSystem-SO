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
}