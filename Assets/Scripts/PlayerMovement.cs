using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float smoothing;
    public float arriveThreshold;
    public CameraReference cameraReference;
    public LayerMask groundLayers;
    public Rigidbody playerRigidbody;
    public GameObject destinationMarker;

    private Vector3? _destination;
    private Vector3 _velocityCursor;

    private void OnEnable()
    {
        destinationMarker.SetActive(false);
    }

    private void Update()
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = cameraReference.value.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, groundLayers.value))
            {
                var dest = hit.point;
                dest.y = 0f;
                _destination = dest;
                destinationMarker.SetActive(true);
                destinationMarker.transform.position = dest;
            }
        }
    }

    private void Move()
    {
        var targetVelocity = Vector3.zero;
        if (_destination != null)
        {
            targetVelocity = (_destination.Value - playerRigidbody.position).normalized * speed;
        }
        playerRigidbody.velocity = Vector3.SmoothDamp(playerRigidbody.velocity, targetVelocity, ref _velocityCursor, smoothing);
        CheckForArrival();
    }

    private void CheckForArrival()
    {
        if (_destination == null) return;
        if (Vector3.Distance(playerRigidbody.position, _destination.Value) < arriveThreshold)
        {
            destinationMarker.SetActive(false);
            _destination = null;
        }
    }

}
