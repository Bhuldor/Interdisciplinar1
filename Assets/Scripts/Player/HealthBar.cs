using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text healthText;
    
   
    public void Sethealth(float health)
    {
        if(health > 0)
            slider.value = health;
        else
            slider.value = 0;
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
        if (currentHealth <= 0)
            currentHealth = 0;
        healthText.text = $"{currentHealth}/{maxHealth}";
    }
}
