using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagedValuesRuntimeEditor : MonoBehaviour
{

    [SerializeField]
    private Transform _defaultParent;
    [SerializeField]
    private ManagedSlider _sliderPrefab;

    protected void CreateSlider(ManagedNumber num, Transform parent = null)
    {
        if (parent == null) parent = _defaultParent;
        var slider = Instantiate(_sliderPrefab, Vector3.zero, Quaternion.identity, parent) as ManagedSlider;
        slider.Bind(num);
    }

}
