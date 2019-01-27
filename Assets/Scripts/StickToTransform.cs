using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToTransform : MonoBehaviour
{

    public Transform stickTo;
    public Vector3 offset;

    private void Update()
    {
        transform.position = stickTo.position + stickTo.TransformVector(offset);
    }

}
