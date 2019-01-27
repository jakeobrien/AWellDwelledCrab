using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DialogMenu : MonoBehaviour
{

    public PlayerState playerState;
    public GrammarRule grammar;
    public TextBubble textBubble;

    private bool _isShowing;
    private float _lastChangeTime;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    public void Show()
    {
        Show(true);
    }

    private void Show(bool show)
    {
        if (_isShowing == show) return;
        if (Time.time - _lastChangeTime < 2f) return;
        _isShowing = show;
        playerState.isInMenu = show;
        if (show) textBubble.Show(grammar.Get());
        else textBubble.Hide();
        _lastChangeTime = Time.time;
    }

    private void Update()
    {
        if (_isShowing && Input.GetKeyDown(KeyCode.Space))
        {
            Show(false);
        }
    }



}
