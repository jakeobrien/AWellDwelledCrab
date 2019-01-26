using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetter : MonoBehaviour
{

    public CameraReference reference;
    public Camera cam;

    private void Awake()
    {
        reference.value = cam;
    }

}
