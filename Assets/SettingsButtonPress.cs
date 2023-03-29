using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonPress : MonoBehaviour
{
    public MenuOptions menu_options;

    public void OnPress()
    {
        menu_options.main_menu.SetActive(false);
        menu_options.settings_menu.SetActive(true);
    }
}
