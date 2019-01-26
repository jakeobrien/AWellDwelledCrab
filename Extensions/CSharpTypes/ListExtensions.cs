using System;
using System.Collections.Generic;

public static class ListExtensions
{
    public static void RemoveObjectsInList<T>(this List<T> list, List<T> objectsToRemove)
    {
        foreach (T obj in objectsToRemove)
        {
            if (list.Contains(obj)) list.Remove(obj);
        }
    }

    public static T GetRandom<T>(this List<T> list)
    {
        return (T)list[UnityEngine.Random.Range(0, list.Count)];
    }

    public static void Shuffle<T>(this List<T> list)
    {
        System.Random rnd = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            T obj = list[k];
            list[k] = list[n];
            list[n] = obj;
        }
    }

	public static T RandomItem<T>(this List<T> list)
	{
		var range = list.Count-1;
		return list[UnityEngine.Random.Range(0, range)];
	}

    public static T Pop<T>(this List<T> list)
    {
        if (list == null || list.Count == 0) return default(T);
        var index = list.Count - 1;
        var item = list[index];
        list.RemoveAt(index);
        return item;
    }

}
