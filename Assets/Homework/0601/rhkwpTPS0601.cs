using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rhkwpTPS0601 : MonoBehaviour
{
    [SerializeField] Transform cameraRoot;
    [SerializeField] float cameraSpeed;
    [SerializeField] float lookDistance;
    [SerializeField] Transform aimTarget;

    private Vector2 lookDelta;
    private float xRotation;
    private float yRotation;

    private void Update()
    {
        Rotate();
    }
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Rotate()
    {
        Vector3 lookPoint = Camera.main.transform.position + Camera.main.transform.forward * lookDistance;
        aimTarget.position = lookPoint;
        lookPoint.y = transform.position.y;
        transform.LookAt(lookPoint);
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void LateUpdate()
    {
        Look();
    }

    private void Look()
    {
        yRotation += lookDelta.x * cameraSpeed * Time.deltaTime;
        xRotation -= lookDelta.y * cameraSpeed * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraRoot.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private void OnLook(InputValue value)
    {
        lookDelta  = value.Get<Vector2>();
    }
}
