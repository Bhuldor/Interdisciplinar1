using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Image menuArrowImage;
    public GameObject menuPanel;
    public Sprite upArrowSprite;
    public Sprite downArrowSprite;

    public GameObject mapPanel;
    public GameObject profilePanel1;
    public GameObject profilePanel2;
 
    public GameObject settingsPanel;
    public GameObject inventoryPanel;
    public GameObject inventoryContentPanel;
    public GameObject descriptionPanel;
    public GameObject equipedPanel;
    public Image fadePanel;
    
    private bool menuIsOpen = false;

    private bool mapPanelIsOpen = false;
    private bool profilePanelIsOpen = false;
  
    private bool settingsPanelIsOpen = false;

    private bool fading = false;

    



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
            menuArrowImage.sprite = upArrowSprite;
            LeanTween.move(menuPanel, menuPanel.transform.position - new Vector3(0, Screen.height * 0.25f, 0), 0.1f);
        }
        else
        {
            menuIsOpen = false;
            menuArrowImage.sprite = downArrowSprite;
            LeanTween.move(menuPanel, menuPanel.transform.position + new Vector3(0, Screen.height * 0.25f, 0), 0.1f);
            CloseOpenedPanels();
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
            LeanTween.scale(mapPanel, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            mapPanelIsOpen = false;
        }
        if (profilePanelIsOpen)
        {
            LeanTween.scale(profilePanel1, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            LeanTween.scale(profilePanel2, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            profilePanelIsOpen = false;
        }
            
        if (MenuInventory.inventoryPanelIsOpen)
        {
            LeanTween.scale(inventoryPanel, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            LeanTween.scale(descriptionPanel, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            LeanTween.scale(equipedPanel, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            MenuInventory.inventoryPanelIsOpen = false;
        }
        if (settingsPanelIsOpen)
        {
            LeanTween.scale(settingsPanel, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            settingsPanelIsOpen = false;
        }
    }

    public void OpenMap()
    {
        if (mapPanelIsOpen)
        {
            CloseOpenedPanels();
            return;
        }
        CloseOpenedPanels();
        mapPanelIsOpen = true;
        LeanTween.scale(mapPanel, new Vector3(1, 1, 1), 0.1f);
    }

    public void OpenProfile()
    {
        if (profilePanelIsOpen)
        {
            CloseOpenedPanels();
            return;
        }
        CloseOpenedPanels();
        profilePanelIsOpen = true;
        LeanTween.scale(profilePanel1, new Vector3(1, 1, 1), 0.1f);
        LeanTween.scale(profilePanel2, new Vector3(1, 1, 1), 0.1f);
    }



  
    public void OpenSettings()
    {
        if (settingsPanelIsOpen)
        {
            CloseOpenedPanels();
            return;
        }
        CloseOpenedPanels();
        settingsPanelIsOpen = true;
        LeanTween.scale(settingsPanel, new Vector3(1, 1, 1), 0.1f);
    }

    public void Map_()
    {

    }

    public void Profile_()
    {

    }
}
