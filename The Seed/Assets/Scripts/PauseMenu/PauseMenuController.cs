using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuCollectables;
    [SerializeField] private GameObject menuOptions;

    private enum Menu
    {
        Main,
        Collectables,
        Options
    }

    private Menu currentMenu;

    private void Start()
    {
        currentMenu = Menu.Main;
    }

    #region Pause Menu

    public void ButtonContinue()
    {

    }

    public void ButtonCollectables()
    {
        menuCollectables.SetActive(true);
        menuPause.SetActive(false);

        currentMenu = Menu.Collectables;
    }

    public void ButtonOptions()
    {
        menuOptions.SetActive(true);
        menuPause.SetActive(false);

        currentMenu = Menu.Options;
    }

    public void ButtonExit()
    {
        
    }

    #endregion

    public void ButtonBack()
    {
        menuPause.SetActive(true);

        switch (currentMenu)
        {
            case Menu.Collectables:
                menuCollectables.SetActive(false);
                currentMenu = Menu.Collectables;
                break;

            case Menu.Options:
                menuOptions.SetActive(false);
                currentMenu = Menu.Options;

                break;
        }
    }
}
