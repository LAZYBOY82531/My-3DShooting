using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] Rig aimRig;
    [SerializeField] float reloadTime;
    [SerializeField] WeaponHolder weaponHolder;
    private Animator anim;
    private bool isReloading;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnReload(InputValue value)
    {
        if(isReloading)
        {
            return;
        }
        StartCoroutine(ReloadRoutine());
    }

    public void Fire()
    {
        weaponHolder.Fire();
        anim.SetTrigger("Fire");
    }
    private void OnFire(InputValue value)
    {
        if(isReloading)
        { return; }
        Fire();
    }

    IEnumerator ReloadRoutine()
    {
        anim.SetTrigger("Reloading");
        isReloading = true;
        aimRig.weight = 0f;
        yield return new WaitForSeconds(reloadTime);
        isReloading=false;
        aimRig.weight = 1.0f;
    }
}
