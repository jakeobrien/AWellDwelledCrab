using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ManagedNumber
{
    string Name { get; }
    float FloatValue { get; set; }
    float MinValue { get; }
    float MaxValue { get; }
    bool WholeNumbers { get; }
}

[System.Serializable]
public class ManagedFloat : ManagedNumber
{

    [SerializeField]
    private string _name;
    [SerializeField]
    private float _value;
    [SerializeField]
    private float _minValue;
    [SerializeField]
    private float _maxValue;

    public string Name { get { return _name; } }

    public float FloatValue
    {

        get { return _value; }
        set { _value = value; }
    }

    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public float MinValue { get { return _minValue; } }

    public float MaxValue { get { return _maxValue; } }

    public bool WholeNumbers { get { return false; } }
}

[System.Serializable]
public class ManagedInt : ManagedNumber
{

    [SerializeField]
    private string _name;
    [SerializeField]
    private int _value;
    [SerializeField]
    private int _minValue;
    [SerializeField]
    private int _maxValue;

    public string Name { get { return _name; } }

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public float FloatValue
    {
        get { return _value; }
        set { _value = (int)value; }
    }

    public float MinValue { get { return (float)_minValue; } }

    public float MaxValue { get { return (float)_maxValue; } }

    public bool WholeNumbers { get { return true; } }
}
