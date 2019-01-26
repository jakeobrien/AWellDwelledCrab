using UnityEngine;

public static class FloatExtensions
{

	public static float Clamp(this float val, float max)
	{
		return Mathf.Min(val, max);
	}

	public static float Clamp(this float val, float max, float min)
	{
		return Mathf.Clamp(val, min, max);
	}

	public static float SignedClamp(this float val, float max)
	{
		return Mathf.Min(val, Mathf.Abs(max)) * Mathf.Sign(val);
	}

	public static float SignedClamp(this float val, float max, float min)
	{
		return Mathf.Clamp(val, Mathf.Abs(min), Mathf.Abs(max)) * Mathf.Sign(val);
	}

}
