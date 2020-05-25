using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text healthText;
    
   
    public void Sethealth(float health)
    {
        slider.value = health;
        UpdateMaxHealthLabel(slider.maxValue, health);
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        UpdateMaxHealthLabel(maxHealth, slider.value);
    }

    private void UpdateMaxHealthLabel(float maxHealth, float currentHealth)
    {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthText.text = $"{currentHealth}/{maxHealth}";
    }
}
