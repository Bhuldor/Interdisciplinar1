using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Image menuArrowImage;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Animator MenuIconAnimator;
    
    [SerializeField] private CanvasGroup mapPanel;
    [SerializeField] private CanvasGroup profilePanel1;
    [SerializeField] private CanvasGroup profilePanel2;
    [SerializeField] private CanvasGroup settingsPanel;
    [SerializeField] private CanvasGroup inventoryPanel;
    [SerializeField] private CanvasGroup descriptionPanel;
    [SerializeField] private CanvasGroup equipedPanel;

    [SerializeField] private Image fadePanel;

    [SerializeField] private MenuInventory menuInventory;

    private int lastMenuOpened;
    
    private bool menuIsOpen = false;

    private bool mapPanelIsOpen = false;
    private bool profilePanelIsOpen = false;
  
    private bool settingsPanelIsOpen = false;

    private bool fading = false;

    public FadeEffect inventoryFadeEffect;



    public void Start()
    {
        transform.position = new Vector3(Screen.width / 2, transform.position.y, transform.position.z);
    }
    public void OpenCloseMenu()
    {
        StartCoroutine(FadePanel());
        
        if (!menuIsOpen)
        {
            menuIsOpen = true;
            MenuIconAnimator.Play("Open");
            OpenlastMenu();
            LeanTween.scaleX(menuPanel, 20f, 0.5f).setEaseInQuint();
        }
        else
        {
            menuIsOpen = false;
            MenuIconAnimator.Play("Close");
            LeanTween.scaleX(menuPanel, 0.0001f, 0.5f).setEaseOutQuint();
            CloseOpenedPanels();
        }
    }

    private void OpenlastMenu()
    {
        switch (lastMenuOpened)
        {
            case 0:
                OpenMap();
                break;
            case 1:
                OpenProfile();
                break;
            case 2:
                OpenProfile();
                break;
            case 3:
                OpenProfile();
                break;
        }
    }

    private IEnumerator FadePanel()
    {
        fading = true;
        fadePanel.enabled = true;
        float alpha = fadePanel.color.a;
        while (fading)
        {
            yield return null;
            if (!menuIsOpen) //needs to fadeOut
            {
                alpha -= 0.1f;
                fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, alpha);
                if (alpha <= 0)
                {
                    fading = false;
                    fadePanel.enabled = false;
                }
            }
            else //needs to fade in
            {
                alpha += 0.1f;
                fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, alpha);
                if (alpha >= 0.6f)
                    fading = false;
            }
        }

        GameManager.PauseGame();
    }
    public void CloseOpenedPanels()
    {
        if (mapPanelIsOpen)
        {
            lastMenuOpened = 0;
            LeanTween.scale(mapPanel.gameObject, new Vector3(0.0001f, 0.0001f, 0.0001f), 0f);
            LeanTween.alphaCanvas(mapPanel, 0, 0.1f);
            mapPanelIsOpen = false;
        }
        if (profilePanelIsOpen)
        {
            lastMenuOpened = 1;
            LeanTween.scale(profilePanel1.gameObject, new Vector3(0.0001f, 0.0001f, 0.0001f), 0f);
            LeanTween.scale(profilePanel2.gameObject, new Vector3(0.0001f, 0.0001f, 0.0001f), 0f);
            LeanTween.alphaCanvas(profilePanel1, 0, 0.1f);
            LeanTween.alphaCanvas(profilePanel2, 0, 0.1f);
            profilePanelIsOpen = false;
        }
            
        if (MenuInventory.inventoryPanelIsOpen)
        {
            lastMenuOpened = 2;
            LeanTween.scale(inventoryPanel.gameObject, new Vector3(0.0001f, 0.0001f, 0.0001f), 0f);
            LeanTween.scale(descriptionPanel.gameObject, new Vector3(0.0001f, 0.0001f, 0.0001f), 0f);
            LeanTween.scale(equipedPanel.gameObject, new Vector3(0.0001f, 0.0001f, 0.0001f), 0f);
            LeanTween.alphaCanvas(inventoryPanel, 0, 0.1f);
            LeanTween.alphaCanvas(descriptionPanel, 0, 0.1f);
            LeanTween.alphaCanvas(equipedPanel, 0, 0.1f);
            inventoryFadeEffect.Activated = false;
            MenuInventory.inventoryPanelIsOpen = false;
        }
        if (settingsPanelIsOpen)
        {
            lastMenuOpened = 3;
            LeanTween.scale(settingsPanel.gameObject, new Vector3(0.0001f, 0.0001f, 0.0001f), 0f);
            LeanTween.alphaCanvas(settingsPanel, 0, 0.1f);
            settingsPanelIsOpen = false;
        }
    }

    public void OpenMap()
    {
        /*
        if (mapPanelIsOpen)
        {
            CloseOpenedPanels();
            return;
        }
        */
        if (!mapPanelIsOpen)
        {
            CloseOpenedPanels();
            mapPanelIsOpen = true;
            LeanTween.scale(mapPanel.gameObject, new Vector3(1, 1, 1), 0f);
            LeanTween.alphaCanvas(mapPanel, 1, 0.1f);
        }
        
    }

    public void OpenProfile()
    {
        /*
        if (profilePanelIsOpen)
        {
            CloseOpenedPanels();
            return;
        }
        */
        if (!profilePanelIsOpen)
        {
            CloseOpenedPanels();
            profilePanelIsOpen = true;
            LeanTween.scale(profilePanel1.gameObject, new Vector3(1, 1, 1), 0f);
            LeanTween.scale(profilePanel2.gameObject, new Vector3(1, 1, 1), 0f);
            LeanTween.alphaCanvas(profilePanel1, 1, 0.1f);
            LeanTween.alphaCanvas(profilePanel2, 1, 0.1f);
        }

    }



  
    public void OpenSettings()
    {
        /*
        if (settingsPanelIsOpen)
        {
            CloseOpenedPanels();
            return;
        }
        */
        if (!settingsPanelIsOpen)
        {
            CloseOpenedPanels();
            settingsPanelIsOpen = true;
            LeanTween.scale(settingsPanel.gameObject, new Vector3(1, 1, 1), 0f);
            LeanTween.alphaCanvas(settingsPanel, 1, 0.1f);
        }
            
        
    }

    public void Map_()
    {

    }

    public void Profile_()
    {

    }
}
