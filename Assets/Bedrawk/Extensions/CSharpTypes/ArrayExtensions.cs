using UnityEngine;
using System;
using System.Collections;

public static class ArrayExtensions
{

    public static T GetRandom<T>(this Array array)
    {
        return (T)array.GetValue(UnityEngine.Random.Range(0, array.Length));
    }

	public static T GetRandom<T>(this T[] array)
	{
		return (T)array.GetValue(UnityEngine.Random.Range(0, array.Length));
	}

	public static T Second<T>(this T[] array)
	{
		if (array == null) return default(T);
		if (array.Length < 1) return default(T);
		return array[1];
	}

    public static T[] Shuffle<T>(this T[] array)
    {
        var rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n);
            n--;
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }

        return array;
    }
}
