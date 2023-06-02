using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhkwpWeaponHolder0601 : MonoBehaviour
{
    [SerializeField] rhkwpGun0601 gun;
    //List<Gun> gunList = new List<Gun>();

    public void Fire()
    {
        gun.Fire();
    }
}
