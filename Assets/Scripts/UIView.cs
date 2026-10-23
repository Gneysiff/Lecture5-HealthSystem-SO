using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIView : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    private void OnEnable()
    {
        // Подписываемся на событие GameManager
        if (gameManager != null)
            gameManager.OnHealthUpdated += UpdateHealthUI;
    }

    private void OnDisable()
    {
        if (gameManager != null)
            gameManager.OnHealthUpdated -= UpdateHealthUI;
    }

    private void UpdateHealthUI(float current, float max)
    {
        healthSlider.maxValue = max;
        healthSlider.value = current;
        healthText.text = $"{current:F0} / {max:F0}"; // Форматирует как 100 / 100
    }
}