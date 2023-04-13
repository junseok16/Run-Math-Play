using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class  : UIManager
    @date   : 2022-08-30
    @author : ????
    @brief  : 
    @warning: 
 */

public class UIManager
{
    // UI ????????????.
    int _order = 10;

    Stack<PopupUI> _stack = new Stack<PopupUI>();
    SceneUI _sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI");
            if (root == null)
            {
                root = new GameObject { name = "@UI" };
            }
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Utilize.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort == true)
        {
            canvas.sortingOrder = _order;
            ++_order;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T OpenSceneUI<T>(string name = null) where T : SceneUI
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }
        GameObject go = Managers.GetResourceManager.Instantiate($"UI/Scene/{ name }");
        T scene = Utilize.GetOrAddComponent<T>(go);
        _sceneUI = scene;

        go.transform.SetParent(Root.transform);
        return scene;
    }

    public T OpenPopupUI<T>(string name = null) where T: PopupUI
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }
        GameObject go = Managers.GetResourceManager.Instantiate($"UI/Popup/{ name }");
        T popup = Utilize.GetOrAddComponent<T>(go);
        _stack.Push(popup);

        go.transform.SetParent(Root.transform);
        return popup;
    }

    public void ClosePopupUI(PopupUI popup)
    {
        if (_stack.Count == 0)
        {
            return;
        }

        if (_stack.Peek() != popup)
        {
            Debug.Log("[UIManager.cs] ");
            return;
        }
        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_stack.Count == 0)
        {
            return;
        }
        PopupUI popup = _stack.Pop();
        Managers.GetResourceManager.Destroy(popup.gameObject);
        popup = null;

        --_order;
    }

    public void CloseAllPopupUI()
    {
        while (_stack.Count > 0)
        {
            ClosePopupUI();
        }
    }

    public void Clear()
    {
        CloseAllPopupUI();
        _sceneUI = null;
    }
}
