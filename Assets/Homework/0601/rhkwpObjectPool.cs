using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rhkwpObjectPool : MonoBehaviour
{
    [SerializeField] rhkwpPoolable pP;

    [SerializeField] int poolSize;
    [SerializeField] int maxSize;

    private Stack<rhkwpPoolable> objectPool = new Stack<rhkwpPoolable>();

    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            rhkwpPoolable poolable = Instantiate(pP);
            poolable.gameObject.SetActive(false);
            poolable.transform.SetParent(transform);
            poolable.Pool = this;
            objectPool.Push(poolable);
        }
    }

    public rhkwpPoolable Get()
    {
        if (objectPool.Count > 0)
        {
            rhkwpPoolable poolable = objectPool.Pop();
            poolable.gameObject.SetActive(true);
            poolable.transform.parent = null;
            return poolable;
        }
        else
        {
            rhkwpPoolable poolable = Instantiate(pP);
            poolable.Pool = this;
            return poolable;
        }
    }

    public void Release(rhkwpPoolable poolable)
    {
        if(objectPool.Count < maxSize)
        {
            poolable.gameObject.SetActive(false);
            poolable.transform.SetParent(transform);
            objectPool.Push(poolable);
        }
        else
        {
            Destroy(poolable.gameObject);
        }
    }
}
