using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnReload(InputValue value)
    {
        anim.SetTrigger("Reloading");
    }

    private void OnFire(InputValue value)
    {
        anim.SetTrigger("Fire");
    }
}
