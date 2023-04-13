using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class  : PoolManager
    @date   : 2022-09-01
    @author : ≈π¡ÿºÆ
    @brief  : 
    @warning: 
 */

public class PoolManager
{
    #region Pool
    class Pool
    {
        public GameObject Origin { get; private set; }
        public Transform Root { get; set; }
        Stack<PoolableObject> _poolStack = new Stack<PoolableObject>();

        public void Initialize(GameObject origin, int count = 5)
        {
            Origin = origin;
            Root = new GameObject().transform;
            Root.name = $"{ origin.name }";

            for (int i = 0; i < count; ++i)
            {
                Push(Create());
            }
        }
        
        PoolableObject Create()
        {
            GameObject go = Object.Instantiate<GameObject>(Origin);
            go.name = Origin.name;
            return go.GetOrAddComponent<PoolableObject>();
        }
        

        public void Push(PoolableObject poolableObject)
        {
            if (poolableObject == null)
            {
                return;
            }
            poolableObject.transform.parent = Root;
            poolableObject.gameObject.SetActive(false);
            poolableObject._isPooled = false;
            _poolStack.Push(poolableObject);
        }

        public PoolableObject Pop(Transform parent = null)
        {
            PoolableObject poolableObject;

            if (_poolStack.Count > 0)
            {
                poolableObject = _poolStack.Pop();
            }
            else
            {
                poolableObject = Create();
            }
            poolableObject.gameObject.SetActive(true);

            if (parent == null)
            {
                poolableObject.transform.parent = Managers.GetSceneManager.BaseScene.transform;
            }

            poolableObject.transform.parent = parent;
            poolableObject._isPooled = true;

            return poolableObject;
        }
    }
    #endregion

    Dictionary<string, Pool> _pool = new Dictionary<string, Pool>();
    Transform _root;

    public void Initialize()
    {
        if (_root == null)
        {
            _root = new GameObject { name = "@Pool" }.transform;
            Object.DontDestroyOnLoad(_root);
        }
    }

    public void Push(PoolableObject poolableObject)
    {
        string name = poolableObject.gameObject.name;
        if (_pool.ContainsKey(name) == false)
        {
            GameObject.Destroy(poolableObject.gameObject);
            return;
        }
        _pool[name].Push(poolableObject);
    }

    public PoolableObject Pop(GameObject origin, Transform parent = null)
    {
        if (_pool.ContainsKey(origin.name) == false)
        {
            CreatePool(origin);
        }
        return _pool[origin.name].Pop(parent);
    }

    public void CreatePool(GameObject origin, int count = 5)
    {
        Pool pool = new Pool();
        pool.Initialize(origin, count);
        pool.Root.parent = _root;

        _pool.Add(origin.name, pool);
    }

    public GameObject GetOriginalObject(string name)
    {
        if (_pool.ContainsKey(name) == false)
        {
            return null;
        }
        return _pool[name].Origin;
    }

    public void Clear()
    {
        foreach(Transform child in _root)
        {
            GameObject.Destroy(child.gameObject);
        }
        _pool.Clear();
    }
}
