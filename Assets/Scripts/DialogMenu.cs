using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DialogMenu : MonoBehaviour
{

    public PlayerState playerState;
    public GrammarRule grammar;
    public TextBubble textBubble;

    private void OnEnable()
    {
        playerState.isInMenu = true;
        textBubble.Show(grammar.Get());
    }

    private void OnDisable()
    {
        playerState.isInMenu = false;
    }



}
