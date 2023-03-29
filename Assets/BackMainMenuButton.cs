using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMainMenuButton : MonoBehaviour
{
    public MenuOptions menu_options;

    public void OnPress()
    {
        menu_options.settings_menu.SetActive(false);
        menu_options.main_menu.SetActive(true);
    }
}
