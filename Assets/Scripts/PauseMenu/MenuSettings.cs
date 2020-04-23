using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    public Sprite yesSprite;
    public Sprite noSprite;

    public Image soundImage;
    public Image musicImage;
    public Image effectsImage;
    public Image brasilImage;
    public Image euaImage;


    private void Start()
    {
        if (GameManager.gameSounds)
            soundImage.sprite = yesSprite;
        else
            soundImage.sprite = noSprite;

        if(GameManager.gameMusics)
            musicImage.sprite = yesSprite;
        else
            musicImage.sprite = noSprite;

        if(GameManager.gameEffects)
            effectsImage.sprite = yesSprite;
        else
            effectsImage.sprite = noSprite;
    }

    public void Settings_sound()
    {
        if (GameManager.gameSounds)
        {
            GameManager.gameSounds = false;
            soundImage.sprite = noSprite;
        }
        else
        {
            GameManager.gameSounds = true;
            soundImage.sprite = yesSprite;
        }

    }
    public void Settings_music()
    {
        if (GameManager.gameMusics)
        {
            GameManager.gameMusics = false;
            musicImage.sprite = noSprite;
        }
        else
        {
            GameManager.gameMusics = true;
            musicImage.sprite = yesSprite;
        }
    }
    public void Settings_effects()
    {
        if (GameManager.gameEffects)
        {
            GameManager.gameEffects = false;
            effectsImage.sprite = noSprite;
        }
        else
        {
            GameManager.gameEffects = true;
            effectsImage.sprite = yesSprite;
        }
    }

    public void ChangeLanguage(string language)
    {
        switch (language)
        {
            case "PT-BR":
                GameManager.selectedLanguage = GameManager.Language.Portuguese;
                euaImage.color = new Color(0.3f, 0.3f, 0.3f);
                brasilImage.color = new Color(1f, 1f, 1f);
                break;
            case "EN-US":
                GameManager.selectedLanguage = GameManager.Language.English; 
                brasilImage.color = new Color(0.3f, 0.3f, 0.3f);
                euaImage.color = new Color(1f, 1f, 1f);
                break;
        }
    }
}
