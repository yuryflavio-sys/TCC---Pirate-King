using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Header("UI Reference")]
    public Image redFillImage;

    [Header("Player Reference")]
    public PlayerHealth playerHealth;

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
            redFillImage.fillAmount = healthPercentage;
        }
    }
}