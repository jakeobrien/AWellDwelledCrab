using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTrigger : MonoBehaviour
{

    public GameObject menuPrompt;
    public GameObject menu;
    public KeyCode menuKey;

    private bool _isShowingMenu;

    private void OnEnable()
    {
        ShowPrompt(false);
        menu.SetActive(false);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (_isShowingMenu) return;
        ShowPrompt(true);
    }

    private void OnTriggerExit(Collider coll)
    {
        if (!_isShowingMenu) return;
        ShowPrompt(false);
    }

    private void Update()
    {
        if (!_isShowingMenu) return;
        if (Input.GetKeyDown(menuKey))
        {
            ShowPrompt(false);
            menu.SetActive(true);
        }
    }

    private void ShowPrompt(bool show)
    {
        _isShowingMenu = show;
        menuPrompt.SetActive(show);
    }

}
