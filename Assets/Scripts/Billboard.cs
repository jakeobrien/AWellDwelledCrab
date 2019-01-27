using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Billboard : MonoBehaviour
{

    public CameraReference cameraRef;
    private Transform _cameraTransform;

    private void Start()
    {
        _cameraTransform = cameraRef.value.transform;
    }

    private void Update()
    {
        var camRot = _cameraTransform.rotation;
        transform.LookAt(transform.position + camRot * Vector3.forward, camRot * Vector3.up);
    }

}
