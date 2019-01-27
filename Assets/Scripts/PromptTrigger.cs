using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PromptTrigger : MonoBehaviour
{

    public TextBubble prompt;
    public KeyCode key;
    public UnityEvent engaged;

    private bool _isShowingMenu;

    private void OnEnable()
    {
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
        if (Input.GetKeyDown(key))
        {
            ShowPrompt(false);
            if (engaged != null) engaged.Invoke();
        }
    }

    private void ShowPrompt(bool show)
    {
        _isShowingMenu = show;
        if (show) prompt.Show(string.Format("Press [{0}]", key.ToString()));
        else prompt.Hide();
    }

}
