using UnityEngine;
using UnityEngine.UI;

public class LevelUpBar : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void SetExpValue(float actualExp)
    {
        slider.value = actualExp;
    }

    public void SetNewLevel(float actualLevelExp, float NextLevelExp)
    {
        slider.minValue = actualLevelExp;
        slider.maxValue = NextLevelExp;
    }
}
