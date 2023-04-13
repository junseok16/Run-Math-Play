using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene _scene { get; protected set; } = Define.Scene.Unknown;

    void Awake()
    {
        Initialize();
    }

    // �̺�Ʈ �ý��� ������Ʈ(@EventSystem)�� �����մϴ�.
    protected virtual void Initialize()
    {
        Object _object = GameObject.FindObjectOfType(typeof(EventSystem));
        if (_object == null)
        {
            Managers.GetResourceManager.Instantiate("UI/EventSystem/EventSystem").name = "@EventSystem";
        }
    }

    public abstract void Clear();
}
