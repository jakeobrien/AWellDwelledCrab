using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBubble : MonoBehaviour
{

    public GameObject visibleRoot;
    public Text text;

    private void OnEnable()
    {
        visibleRoot.SetActive(false);
    }

    public void Show(string t)
    {
        visibleRoot.SetActive(true);
        text.text = t;
    }

    public void Hide()
    {
        visibleRoot.SetActive(false);
    }

}
