using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class rhkwpPoolable : MonoBehaviour
{
    [SerializeField] private bool autoRelease;
    [SerializeField] private float releaseTime;

    private rhkwpObjectPool pool;
    public rhkwpObjectPool Pool { get { return pool; } set { pool = value; } }

    private void OnEnable()
    {
        StartCoroutine(ReleaseTimer());
    }

    IEnumerator ReleaseTimer()
    {
        yield return new WaitForSeconds(releaseTime);
        pool.Release(this);
    }
}
