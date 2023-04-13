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
        // UI ������ �׼��� �߻��� ���, �׼��� �����մϴ�.
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

        // Ű���� �׼��� �߻��� ���,
        if (Input.anyKey && KeyAction != null) { KeyAction.Invoke(); }

        // ���콺 �׼��� �߻��� ���,
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
