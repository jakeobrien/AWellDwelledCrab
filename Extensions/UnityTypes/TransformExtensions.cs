using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{

    public static void SetX(this Transform tr, float x)
    {
        var pos = tr.position;
        pos.x = x;
        tr.position = pos;
    }

    public static void SetY(this Transform tr, float y)
    {
        var pos = tr.position;
        pos.y = y;
        tr.position = pos;
    }

    public static void SetZ(this Transform tr, float z)
    {
        var pos = tr.position;
        pos.z = z;
        tr.position = pos;
    }

    public static void SetLocalX(this Transform tr, float x)
    {
        var pos = tr.localPosition;
        pos.x = x;
        tr.localPosition = pos;
    }

    public static void SetLocalY(this Transform tr, float y)
    {
        var pos = tr.localPosition;
        pos.y = y;
        tr.localPosition = pos;
    }

    public static void SetLocalZ(this Transform tr, float z)
    {
        var pos = tr.localPosition;
        pos.z = z;
        tr.localPosition = pos;
    }

    public static float LocalRotation2D(this Transform tr)
    {
        return tr.localEulerAngles.z;
    }

    public static void SetLocalRotation2D(this Transform tr, float rotation)
    {
        tr.localEulerAngles = new Vector3(0f, 0f, rotation);
    }

    public static float Rotation2D(this Transform tr)
    {
        return tr.eulerAngles.z;
    }

    public static void SetRotation2D(this Transform tr, float rotation)
    {
        tr.eulerAngles = new Vector3(0f, 0f, rotation);
    }

}
