using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagedSlider : MonoBehaviour
{

    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private Text _nameLabel;
    [SerializeField]
    private Text _valueLabel;
    private ManagedNumber _number;
    private bool _throttleValueChangeUpdates;

    public void Bind(ManagedNumber number)
    {
        _number = number;
        Layout();
    }

    public float Value
    {
        get { return _slider.value; }
    }

    private void Layout()
    {
        if (_number == null) return;
        _nameLabel.text = _number.Name;
        _throttleValueChangeUpdates = true;
        _slider.minValue = _number.MinValue;
        _slider.maxValue = _number.MaxValue;
        _slider.wholeNumbers = _number.WholeNumbers;
        _slider.value = _number.FloatValue;
        _throttleValueChangeUpdates = false;
        ValueChanged(_slider.value);
    }

    private void OnEnable()
    {
        Layout();
        _slider.onValueChanged.AddListener(ValueChanged);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveAllListeners();
    }

    private void ValueChanged(float val)
    {
        if (!_throttleValueChangeUpdates && _number != null) _number.FloatValue = val;
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        if (_number == null) return;
        _valueLabel.text = string.Format("{0}", _number.FloatValue);
    }

}
