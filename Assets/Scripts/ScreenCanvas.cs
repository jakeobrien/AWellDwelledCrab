using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenCanvas : MonoBehaviour
{

    public Canvas canvas;
    public CameraReference cameraRef;
    public bool billboard;
    private Transform _cameraTransform;

    private void Start()
    {
        canvas.worldCamera = cameraRef.value;
        _cameraTransform = cameraRef.value.transform;
    }

    private void Update()
    {
        if (billboard) Billboard();
    }

    private void Billboard()
    {
        var camRot = _cameraTransform.rotation;
        transform.LookAt(transform.position + camRot * Vector3.forward, camRot * Vector3.up);
    }

}
