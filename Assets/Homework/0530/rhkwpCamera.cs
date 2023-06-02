using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rhkwpCamera : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera Camera;

    private void OnMoveCamera(InputValue value)
    {
        if (Camera.Priority == 20)
        {
            Camera.Priority = 5;
        }
        else
        {
            Camera.Priority = 20;
        }
    }
}
