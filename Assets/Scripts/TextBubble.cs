using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
        visibleRoot.transform.DOKill();
        visibleRoot.transform.localScale = Vector3.one * 0.1f;
        visibleRoot.transform.DOScale(1f, 0.4f).SetEase(Ease.OutElastic);
        text.text = t;
    }

    public void Hide()
    {
        visibleRoot.transform.DOScale(0.1f, 0.4f).OnComplete(() => { visibleRoot.SetActive(false); });
    }

}
