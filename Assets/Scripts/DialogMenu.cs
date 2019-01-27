using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogMenu : MonoBehaviour
{

    public GrammarRule grammar;
    public TextBubble textBubble;
    public UnityEvent StartedTalking;
    public UnityEvent StoppedTalking;
    private bool _isShowing;
    private float _lastChangeTime;

    public void Show()
    {
        Show(true);
    }

    public void Hide()
    {
        Show(false);
    }

    private void Show(bool show)
    {
        if (_isShowing == show) return;
        if (Time.time - _lastChangeTime < 2f) return;
        _isShowing = show;
        if (show) textBubble.Show(grammar.Get());
        else textBubble.Hide();
        _lastChangeTime = Time.time;
        if (show && StartedTalking != null) StartedTalking.Invoke();
        else if (!show && StoppedTalking != null) StoppedTalking.Invoke();
    }

}
