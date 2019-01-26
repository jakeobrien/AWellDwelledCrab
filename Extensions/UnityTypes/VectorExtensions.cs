using UnityEngine;
using Random = UnityEngine.Random;

public static class VectorExtensions
{

	public static float ToAngle(this Vector2 vector)
	{
		return Mathf.Atan2(vector.y, vector.x);
	}
	public static float ToAngleDeg(this Vector2 vector)
	{
		return vector.ToAngle() * Mathf.Rad2Deg;
	}

	//ditch these if Angle struct is good
	public static Vector2 Vector2FromAngle(float angle)
	{
		float x = Mathf.Cos(angle);
		float y = Mathf.Sin(angle);
		return new Vector2(x, y);
	}
	public static Vector2 Vector2FromAngleDeg(float angle)
	{
		return Vector2FromAngle(angle * Mathf.Deg2Rad);
	}

	public static Vector2 RandomNormalizedVector2()
	{
		var angle = Random.Range(0f, Mathf.PI * 2f);
		return Vector2FromAngle(angle);
	}

    public static Vector2 Rotate(this Vector2 v, float rads)
	{
		float sin = Mathf.Sin(rads);
		float cos = Mathf.Cos(rads);
		var x = (cos * v.x) - (sin * v.y);
		var y = (sin * v.x) + (cos * v.y);
		return new Vector2(x, y);
    }
    public static Vector2 RotateDeg(this Vector2 v, float degrees)
	{
		return v.Rotate(degrees * Mathf.Deg2Rad);
    }

	public static Vector3 ToVector3 (this Vector2 v2)
	{
		return new Vector3(v2.x, v2.y, 0f);
	}
	public static Vector2 ToVector2 (this Vector3 v3)
	{
		return new Vector2(v3.x, v3.y);
	}


	public static Vector2 Abs(this Vector2 v2)
	{
		return new Vector2(Mathf.Abs(v2.x), Mathf.Abs(v2.y));
	}
	public static Vector3 Abs(this Vector3 v3)
	{
		return new Vector3(Mathf.Abs(v3.x), Mathf.Abs(v3.y), Mathf.Abs(v3.z));
	}


	public static Vector2 ClampMagnitude(Vector2 v, float max)
	{
		return Mathf.Min(v.magnitude, max) * v.normalized;
	}
	public static Vector3 ClampMagnitude(Vector3 v, float max)
	{
		return Mathf.Min(v.magnitude, max) * v.normalized;
	}


	public static Vector2 ClampMagnitude(Vector2 v, float min, float max)
	{
		return Mathf.Clamp(v.magnitude, min, max) * v.normalized;
	}
	public static Vector3 ClampMagnitude(Vector3 v, float min, float max)
	{
		return Mathf.Clamp(v.magnitude, min, max) * v.normalized;
	}

	public static Vector2 Inverse(this Vector2 v2)
	{
		return new Vector2(1f / v2.x, 1f / v2.y);
	}
	public static Vector3 Inverse(this Vector3 v3)
	{
		return new Vector3(1f / v3.x, 1f / v3.y, 1f / v3.z);
	}


	public static Vector3 PositionComponent(this Matrix4x4 q)
	{
		return new Vector3(q[0,3], q[1,3], q[2,3]);
	}

	public static Vector3 ScaleComponent(this Matrix4x4 q)
	{
		return new Vector3(q[0,0], q[1,1], q[2,2]);
	}

}
