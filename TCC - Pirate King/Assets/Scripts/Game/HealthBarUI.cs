using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Header("UI Reference")]
    public Image redFillImage; // Arraste o seu objeto RedFill para cá no Inspector

    [Header("Player Reference")]
    public PlayerHealth playerHealth; // Arraste o Player para cá no Inspector

    private void OnEnable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealthBar;
        }
    }

    private void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }

    private void UpdateHealthBar(float healthPercentage)
    {
        if (redFillImage != null)
        {
            // O Fill Amount vai descer em 3 partes exatas (1.0 -> 0.66 -> 0.33 -> 0)
            redFillImage.fillAmount = healthPercentage;
        }
    }
}