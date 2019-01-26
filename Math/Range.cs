using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

/// <summary>
/// Range. Takes min and max values, and return random between.
/// </summary>

[System.Serializable]
public struct Range
{

	[SerializeField]
	[FormerlySerializedAs("Min")]
	private float _min;
	public float Min
	{
		get { return _min; }
		set { _min = value; }
	}

	[SerializeField]
	[FormerlySerializedAs("Max")]
	private float _max;
	public float Max
	{
		get { return _max; }
		set { _max = value; }
	}

	public Range(float min, float max)
	{
		_min = min;
		_max = max;
	}

	public float RandomInRange
	{
		get { return Random.Range(Min, Max); }
	}

	public bool IsValueInRange(float value)
	{
		return (value >= Min && value <= Max);
	}

	public float Lerp(float t)
	{
		return Mathf.Lerp(Min, Max, t);
	}

	public float Normalize(float t)
	{
		return Mathf.Clamp01(Mathf.InverseLerp(Min, Max, t));
	}

	public float Clamp(float v)
	{
		return Mathf.Clamp(v, Min, Max);
	}

	public override string ToString()
	{
		return string.Format("<Range> Min:{0} Max:{1}", Min, Max);
	}

}
