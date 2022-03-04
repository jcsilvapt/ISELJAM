using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuMain;
    [SerializeField] private GameObject menuCollectables;
    [SerializeField] private GameObject menuOptions;
    [SerializeField] private GameObject menuCredits;

    private enum Menu
    {
        Main,
        Collectables,
        Options,
        Credits
    }

    private Menu currentMenu;

    private void Start()
    {
        currentMenu = Menu.Main;
    }

    #region Main Menu

    public void ButtonPlay()
    {

    }

    public void ButtonCollectables()
    {
        menuCollectables.SetActive(true);
        menuMain.SetActive(false);

        currentMenu = Menu.Collectables;
    }

    public void ButtonOptions()
    {
        menuOptions.SetActive(true);
        menuMain.SetActive(false);

        currentMenu = Menu.Options;
    }

    public void ButtonCredits()
    {
        menuCredits.SetActive(true);
        menuMain.SetActive(false);

        currentMenu = Menu.Credits;
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    #endregion

    public void ButtonBack()
    {
        menuMain.SetActive(true);

        switch(currentMenu)
        {
            case Menu.Collectables:
                menuCollectables.SetActive(false);
                currentMenu = Menu.Collectables;
                break;

            case Menu.Options:
                menuOptions.SetActive(false);
                currentMenu = Menu.Options;

                break;
            case Menu.Credits:
                menuCredits.SetActive(false);
                currentMenu = Menu.Credits;

                break;
        }
    }
}
