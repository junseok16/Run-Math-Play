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

    // 이벤트 시스템 오브젝트(@EventSystem)를 생성합니다.
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
