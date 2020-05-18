using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    private bool inEffect = true;
    private Color originalColor;
    private Text textToFade;
    private Image imageToFade;
    [SerializeField] private Color targetColorAlpha;
    [SerializeField] [Range(0.01f, 0.2f)] private float duration = 0.025f;
    public bool Activated = false;
    bool change = false;
    float t = 0f;

    private enum Mode
    {
        TextColor,
        ImageAlpha
    }
    private enum Start
    {
        OnAwake,
        OnEnable
    }

    [SerializeField] private Mode mode = Mode.TextColor;
    [SerializeField] private Start start = Start.OnAwake;

    private void Awake()
    {
        switch (mode)
        {
            case Mode.TextColor:
                textToFade = GetComponent<Text>();
                if (textToFade != null)
                    originalColor = textToFade.color;
                else
                    Debug.LogError("Text component not found!");
                break;

            case Mode.ImageAlpha:
                imageToFade = GetComponent<Image>();
                if (imageToFade != null)
                    originalColor = imageToFade.color;
                else
                    Debug.LogError("Image component not found!");
                break;

        }

        if (start == Start.OnAwake)
            inEffect = true;
    }

    void Update()
    {
        if (inEffect && Activated)
        {
            switch (mode)
            {
                case Mode.TextColor:
                    textToFade.color = Color.Lerp(originalColor, targetColorAlpha, t);
                    if (!change)
                        t += duration;
                    else
                        t -= duration;
                    if (t >= 1)
                        change = true;
                    if (t <= 0)
                        change = false;
                    break;

                case Mode.ImageAlpha:
                    //imageToFade.CrossFadeAlpha(targetColorAlpha.a, duration, true);
                    //Work on it when i need
                    break;
            }
        }
    }
    private void OnEnable()
    {
        if(start == Start.OnEnable)
            inEffect = true;
    }

    private void OnDisable()
    {
        if (start == Start.OnEnable)
            inEffect = false;
    }
}
