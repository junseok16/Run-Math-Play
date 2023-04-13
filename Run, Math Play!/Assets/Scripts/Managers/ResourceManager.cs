using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class  : ResourceManager
    @date   : 2022-08-30
    @author : Ź�ؼ�
    @brief  : �������� �ſ� �ν��Ͻ�ȭ�մϴ�.
    @warning: 
 */

public class ResourceManager
{
    // Prefabs ���� �ȿ� �ִ� �������� �ε��մϴ�.
    public T Load<T>(string path) where T : Object
    {
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0)
            {
                name = name.Substring(index + 1);
            }

            GameObject go = Managers.GetPoolManager.GetOriginalObject(name);
            if (go != null)
            {
                return go as T;
            }
        }
        
        return Resources.Load<T>(path);
    }

    // �ε��� �������� �ſ� �ν��Ͻ�ȭ�մϴ�.
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject origin = Load<GameObject>($"Prefabs/{ path }");
        if (origin == null)
        {
            Debug.Log($"[ResourceManager.cs] { path } �������� �ε��� �� �����ϴ�.");
            return null;
        }

        if (origin.GetComponent<PoolableObject>() != null)
        {
            return Managers.GetPoolManager.Pop(origin, parent).gameObject;
        }

        GameObject go = Object.Instantiate(origin, parent);
        go.name = origin.name;
        return go;
    }

    // �ν��Ͻ�ȭ�� �������� �ſ��� �����մϴ�.
    public void Destroy(GameObject go)
    {
        if (go == null) {
            Debug.Log("[ResourceManager.cs] �������� ������ �� �����ϴ�.");
            return;
        }

        PoolableObject poolableObject = go.GetComponent<PoolableObject>();
        if (poolableObject != null)
        {
            Managers.GetPoolManager.Push(poolableObject);
            return;
        }

        Object.Destroy(go);
    }
}
