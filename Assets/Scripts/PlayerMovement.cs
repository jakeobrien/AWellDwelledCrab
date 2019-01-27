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
    public CameraReference cameraReference;
    public CharacterController controller;
    public GameObject destinationMarker;
    public Animator animator;

    private Vector3? _destination;
    private Vector3 _velocityCursor;
    private Vector3 _direction;
    private Vector3 _velocity;

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
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }

    private void Move()
    {
        var targetVelocity = cameraReference.value.transform.forward * _direction.z;
        targetVelocity += cameraReference.value.transform.right * _direction.x;
        targetVelocity.y = 0f;
        targetVelocity = targetVelocity.normalized * speed;
        _velocity = Vector3.SmoothDamp(_velocity, targetVelocity, ref _velocityCursor, smoothing);
        controller.SimpleMove(_velocity);
        var targetRotation = Quaternion.LookRotation(controller.transform.forward, Vector3.up);
        if (controller.velocity.sqrMagnitude > 1f) targetRotation = Quaternion.LookRotation(controller.velocity.normalized, Vector3.up);
        if (_direction.x != 0f) targetRotation = Quaternion.RotateTowards(targetRotation, Quaternion.LookRotation(cameraReference.value.transform.right * _direction.x, Vector3.up), 90f);
        // targetRotation *= Quaternion.AngleAxis(Mathf.PerlinNoise(Time.time * rotationNoiseSpeed, 0f) * rotationNoise, Vector3.up);
        var rotation = Quaternion.RotateTowards(controller.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        controller.transform.rotation = rotation;
        animator.SetFloat("walkSpeed", _velocity.magnitude);
    }

}
