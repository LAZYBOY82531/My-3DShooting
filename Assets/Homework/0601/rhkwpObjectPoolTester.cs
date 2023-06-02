using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhkwpObjectPoolTester : MonoBehaviour
{
    private rhkwpObjectPool objectPool;

    private void Awake()
    {
        objectPool = GetComponent<rhkwpObjectPool>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rhkwpPoolable poolable = objectPool.Get();
            poolable.transform.position = new Vector3(Random.Range(-7f, 7f), 0, Random.Range(-7f, 7f));
        }
    }
}
