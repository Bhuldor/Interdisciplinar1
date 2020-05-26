using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    private bool inEffect = true;
    private Color originalColor;
    private Text textToFade;
    private Image imageToFade;
    [SerializeField] private Color targetColorAlpha;
    [SerializeField] [Range(0.01f, 2f)] private float duration = 0.025f;
    public bool Activated = false;
    private bool change = false;
    private float t = 0f;
    public bool transparent = false;
    public bool onGoing = false;
    private RectTransform textRectTransform;

    private enum Mode
    {
        TextColor,
        TextAlpha,
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
            case Mode.TextAlpha:
                textRectTransform = GetComponent<RectTransform>();
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
                case Mode.TextAlpha:
                    if (!transparent)
                    {
                        LeanTween.alphaText(textRectTransform, targetColorAlpha.a, duration );
                    }
                    else
                    {
                        LeanTween.alphaText(textRectTransform, 1, duration);
                    }
                    StartCoroutine(waitTextAlpha());
                    break;
            }
        }
    }

    IEnumerator waitTextAlpha()
    {
        if (!onGoing)
        {
            onGoing = true;
            yield return new WaitForSeconds(duration*2);
            transparent = !transparent;
            onGoing = false;
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
