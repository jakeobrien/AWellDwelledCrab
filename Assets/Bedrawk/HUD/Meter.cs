using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{

    [SerializeField]
    private float _feedbackStrength;
    [SerializeField][Range(0,1)]
    private float _feedbackDecay;
    [SerializeField]
    private Image _fill;

    [SerializeField]
    private Image _delayFill;
    [SerializeField]
    private Gradient _gradient;
    [SerializeField]
    private Gradient _delayGradient;

    private float _value;
    public float Value
    {
        get { return _value; }
        set
        {
            if (_value == value) return;
            _value = Mathf.Clamp01(value);
            _fill.fillAmount = _value;
            _fill.color = _gradient.Evaluate(_value);
            StartCoroutine(Animate());
            StartCoroutine(DelayedFill(_value));
        }
    }

    private void Start()
    {
        Value = 1f;
    }

    private IEnumerator Animate()
    {
        var eulers = transform.localEulerAngles;
        var rot = _feedbackStrength;
        while (Mathf.Abs(rot) > 1f)
        {
            eulers.z = rot;
            transform.localEulerAngles = eulers;
            rot *= -_feedbackDecay;
            yield return null;
        }
        eulers.z = 0f;
        transform.localEulerAngles = eulers;
    }

    private IEnumerator DelayedFill(float val)
    {
        yield return new WaitForSeconds(0.7f);
        _delayFill.color = _delayGradient.Evaluate(val);
        _delayFill.fillAmount = _value;
    }

}
