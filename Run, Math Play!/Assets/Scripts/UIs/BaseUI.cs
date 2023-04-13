using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();


    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; ++i)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objects[i] = Utilize.FindChild(gameObject, names[i], true);
            }

            else
            {
                objects[i] = Utilize.FindChild<T>(gameObject, names[i], true);
            }

            if (objects[i] == null)
            {
                Debug.Log($"[BaseUI.cs] { names[i] }");
            }
        }
    }

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
        {
            Debug.Log($"[BaseUI.cs]");
            return null;
        }
        return objects[index] as T;
    }

    protected Text GetText(int index) { return Get<Text>(index); }
    protected Button GetButton(int index) { return Get<Button>(index); }
    protected Image GetImage(int index) { return Get<Image>(index); }
    protected GameObject GetGameObject(int index) { return Get<GameObject>(index); }
    protected TEXDraw GetTEXDraw(int index) { return Get<TEXDraw>(index); }
    protected TextMeshProUGUI GetTextMeshProUGUI(int index) { return Get<TextMeshProUGUI>(index); }

    public static void BindEvent(GameObject go, Action<PointerEventData> action, Define.UI type = Define.UI.Click)
    {
        UIEventHandler eventHandler = Utilize.GetOrAddComponent<UIEventHandler>(go);

        switch (type)
        {
            case Define.UI.Click:
                eventHandler.OnPointerClickAction -= action;
                eventHandler.OnPointerClickAction += action;
                break;

            case Define.UI.BeginDrag:
                eventHandler.OnBeginDragAction -= action;
                eventHandler.OnBeginDragAction += action;
                break;

            case Define.UI.Drag:
                eventHandler.OnDragAction -= action;
                eventHandler.OnDragAction += action;
                break;

            case Define.UI.EndDrag:
                eventHandler.OnEndDragAction -= action;
                eventHandler.OnEndDragAction += action;
                break;
        }
    }
}
