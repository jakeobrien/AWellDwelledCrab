using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SpawnItem
{
    public GameObject[] prefabs;
    public int count;
    public float yPos;
    public Vector3 rotationRandomness;
    public float scaleRandomness = 1f;
    public bool autoSpawn;

    public GameObject RandomPrefab()
    {
        return prefabs.GetRandom();
    }

    public Quaternion RandomRot()
    {
        if (rotationRandomness == Vector3.zero) return Quaternion.identity;
        return Quaternion.AngleAxis(rotationRandomness.x, Vector3.right) * Quaternion.AngleAxis(rotationRandomness.y, Vector3.up) * Quaternion.AngleAxis(rotationRandomness.z, Vector3.forward);
    }

}

public class Spawner : MonoBehaviour
{

    public Rect area;
    public SpawnItem[] spawnItems;


    private void Start()
    {
        AutoSpawn();
    }

    private void AutoSpawn()
    {
        foreach (var item in spawnItems)
        {
            if (item.autoSpawn) Spawn(item);
        }
    }

    public void Spawn(SpawnItem item)
    {
        for (int i = 0; i < item.count; i++)
        {
            var pos = RandomPos();
            pos.y = item.yPos;
            var rot = item.RandomRot();
            var o = Instantiate(item.RandomPrefab(), pos, rot);
            o.transform.localScale *= UnityEngine.Random.Range(1f/item.scaleRandomness, item.scaleRandomness);
        }
    }

    private Vector3 RandomPos()
    {
        return new Vector3(UnityEngine.Random.Range(area.xMin, area.xMax), 0f, UnityEngine.Random.Range(area.yMin, area.yMax));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector3(area.center.x, 0f, area.center.y), new Vector3(area.size.x, 5f, area.size.y));
    }

}
