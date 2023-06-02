using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] int damage;
    [SerializeField] float bulletSpeed;
    [SerializeField] ParticleSystem muzzleEffect;
    [SerializeField] TrailRenderer bulletTrail;

    public void Fire()
    {
        muzzleEffect.Play();

        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistance))
        {
            IHitable hitable = hit.transform.GetComponent<IHitable>();
            ParticleSystem effect = GameManager.Resource.Instantiate<ParticleSystem>("prefab/HitEffect", hit.point, Quaternion.LookRotation(hit.normal), true);
            effect.transform.parent = hit.transform;
            StartCoroutine(ReleaseRoutine(effect.gameObject));

            StartCoroutine(TrailRoutinue(muzzleEffect.transform.position, hit.point));

            hitable?.Hit(hit, damage);
        }
        else
        {
            StartCoroutine(TrailRoutinue(muzzleEffect.transform.position, Camera.main.transform.forward * maxDistance));
        }
    }

    IEnumerator ReleaseRoutine(GameObject effect)
    {
        yield return new WaitForSeconds(3f);
        GameManager.Pool.Release(effect);
    }

    IEnumerator TrailRoutinue(Vector3 startPoint, Vector3 endPoint)
    {
        TrailRenderer trail = GameManager.Pool.Get(bulletTrail, startPoint, Quaternion.identity);
        trail.Clear();
        trail.GetComponent<TrailRenderer>().Clear();

        float totalTime = Vector2.Distance(startPoint, endPoint) / bulletSpeed;

        float rate = 0;
        while (rate < 1)
        {
            trail.transform.position = Vector3.Lerp(startPoint, endPoint, rate);
            rate += Time.deltaTime / totalTime;

            yield return null;
        }
        GameManager.Pool.Release(trail.gameObject);
    }
}
