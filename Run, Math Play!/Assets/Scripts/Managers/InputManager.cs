using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.Mouse> MouseAction = null;
    bool _pressed = false;

    public void OnUpdate()
    {
        // UI 위에서 액션이 발생한 경우, 액션을 무시합니다.
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

        // 키보드 액션이 발생한 경우,
        if (Input.anyKey && KeyAction != null) { KeyAction.Invoke(); }

        // 마우스 액션이 발생한 경우,
        if (MouseAction != null)
        {
            if (Input.GetMouseButton(1))
            {
                MouseAction.Invoke(Define.Mouse.Press);
                _pressed = true;
            }
            else
            {
                if (_pressed == true) { MouseAction.Invoke(Define.Mouse.Click); }
                _pressed = false;
            }
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
