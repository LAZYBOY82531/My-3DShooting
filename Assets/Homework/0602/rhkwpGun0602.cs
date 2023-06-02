using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhkwpGun0602 : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] int damage;
    [SerializeField] float bulletSpeed;
    [SerializeField] ParticleSystem muzzleEffect;

    public void Fire()
    {
        muzzleEffect.Play();

        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            IHitable hitable = hit.transform.GetComponent<IHitable>();
            ParticleSystem effect = GameManagerrhkwp.Resource.Instantiate<ParticleSystem>("prefab/HitEffect", hit.point, Quaternion.LookRotation(hit.normal));
            effect.transform.parent = hit.transform;
            Destroy(effect.gameObject, 2f);

            StartCoroutine(TrailRoutinue(muzzleEffect.transform.position, hit.point));

            hitable?.Hit(hit, damage);
        }
        else
        {
            StartCoroutine(TrailRoutinue(muzzleEffect.transform.position, Camera.main.transform.forward * maxDistance));
        }
    }

    IEnumerator TrailRoutinue(Vector3 startPoint, Vector3 endPoint)
    {
        TrailRenderer trail = GameManagerrhkwp.Resource.Instantiate<TrailRenderer>("prefab/BulletTrail", muzzleEffect.transform.position, Quaternion.identity);
        float totalTime = Vector2.Distance(startPoint, endPoint) / bulletSpeed;
        float rate = 0;
        while (rate < 1)
        {
            trail.transform.position = Vector3.Lerp(startPoint, endPoint, rate);
            rate += Time.deltaTime / totalTime;

            yield return null;
        }
        Destroy(trail);
    }
}
