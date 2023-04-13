using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilize
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
        {
            component = go.AddComponent<T>();
        }
        return component;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
        {
            return null;
        }
        return transform.gameObject;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
        {
            return null;
        }

        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; ++i)
            {
                Transform transfrom = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transfrom.name == name)
                {
                    T component = transfrom.GetComponent<T>();
                    if (component != null)
                    {
                        return component;
                    }
                }
            }
        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                {
                    return component;
                }
            }
        }
        return null;
    }
    
    public static GameObject[] FindChildren(GameObject go)
    {
        int childCount = go.transform.childCount;
        if (childCount == 0)
        {
            return null;
        }
        
        GameObject[] children = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {
            children[i] = go.transform.GetChild(i).gameObject;
        }
        return children;
    }
}
