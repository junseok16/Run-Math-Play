using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class  : ResourceManager
    @date   : 2022-08-30
    @author : 탁준석
    @brief  : 프리팹을 신에 인스턴스화합니다.
    @warning: 
 */

public class ResourceManager
{
    // Prefabs 폴더 안에 있는 프리팹을 로드합니다.
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

    // 로드한 프리팹을 신에 인스턴스화합니다.
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject origin = Load<GameObject>($"Prefabs/{ path }");
        if (origin == null)
        {
            Debug.Log($"[ResourceManager.cs] { path } 프리팹을 로드할 수 없습니다.");
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

    // 인스턴스화된 프리팹을 신에서 삭제합니다.
    public void Destroy(GameObject go)
    {
        if (go == null) {
            Debug.Log("[ResourceManager.cs] 프리팹을 삭제할 수 없습니다.");
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
