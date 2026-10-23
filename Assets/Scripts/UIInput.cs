using UnityEngine;
using UnityEngine.UI;

public class UIInput : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Button damageButton;
    [SerializeField] private Button healButton;
    [SerializeField] private float damageValue = 10f;
    [SerializeField] private float healValue = 15f;

    private void Start()
    {
        damageButton.onClick.AddListener(() => gameManager.DamageNPC(damageValue));
        healButton.onClick.AddListener(() => gameManager.HealNPC(healValue));
    }
}