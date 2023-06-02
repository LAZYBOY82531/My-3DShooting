using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEditor.EditorTools;
using UnityEngine;

public class GameManagerrhkwp : MonoBehaviour
{
    private static GameManagerrhkwp instance;
    private static PoolManagerrhkwp poolManager;
    private static ResourceManagerrhkwp resourceManager;

    public static GameManagerrhkwp Instance { get { return instance; } }
    public static PoolManagerrhkwp Pool { get { return poolManager; } }
    public static ResourceManagerrhkwp Resource { get { return resourceManager; } }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
        InitManagers();
    }

    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    private void InitManagers()
    {
        GameObject poolObj = new GameObject();
        poolObj.name = "PoolManager";
        poolObj.transform.parent = transform;
        poolManager = poolObj.AddComponent<PoolManagerrhkwp>();

        GameObject resourceObj = new GameObject();
        resourceObj.name = "ResourceManager";
        resourceObj.transform.parent = transform;
        resourceManager = resourceObj.AddComponent<ResourceManagerrhkwp>();
    }
}