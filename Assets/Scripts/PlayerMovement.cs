using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float smoothing;
    public float rotationNoise;
    public float rotationNoiseSpeed;
    public PlayerState playerState;
    public CameraReference cameraReference;
    public Rigidbody playerRigidbody;
    public GameObject destinationMarker;

    private Vector3? _destination;
    private Vector3 _velocityCursor;
    private Vector3 _direction;

    private void OnEnable()
    {
        playerState.isInMenu = false;
        destinationMarker.SetActive(false);
    }

    private void Update()
    {
        if (playerState.isInMenu)
        {
            playerRigidbody.velocity = Vector3.zero;
            return;
        }
        GetInput();
        Move();
    }

    private void GetInput()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }

    private void Move()
    {
        var targetVelocity = cameraReference.value.transform.forward * _direction.z;
        targetVelocity += cameraReference.value.transform.right * _direction.x;
        targetVelocity.y = 0f;
        targetVelocity = targetVelocity.normalized * speed;
        playerRigidbody.velocity = Vector3.SmoothDamp(playerRigidbody.velocity, targetVelocity, ref _velocityCursor, smoothing);
        var targetRotation = Quaternion.LookRotation(playerRigidbody.transform.forward, Vector3.up);
        if (playerRigidbody.velocity.sqrMagnitude > 1f) targetRotation = Quaternion.LookRotation(playerRigidbody.velocity.normalized, Vector3.up);
        if (_direction.x != 0f) targetRotation = Quaternion.RotateTowards(targetRotation, Quaternion.LookRotation(cameraReference.value.transform.right * _direction.x, Vector3.up), 90f);
        // targetRotation *= Quaternion.AngleAxis(Mathf.PerlinNoise(Time.time * rotationNoiseSpeed, 0f) * rotationNoise, Vector3.up);
        var rotation = Quaternion.RotateTowards(playerRigidbody.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        playerRigidbody.rotation = rotation;
    }

}
