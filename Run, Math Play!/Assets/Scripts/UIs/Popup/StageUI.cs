using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StageUI : PopupUI
{
    enum Buttons
    {
        CrossTheBridgeList,
        CatchTheSpyList,
        MacManList,
        Button_Close
    }

    enum Texts { }

    enum Images { }

    enum GameObjects { }

    private void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));

        GameObject buttonCrossTheBridge = GetButton((int)Buttons.CrossTheBridgeList).gameObject;
        GameObject buttonCatchTheSpy = GetButton((int)Buttons.CatchTheSpyList).gameObject;
        GameObject buttonMacMan = GetButton((int)Buttons.MacManList).gameObject;
        GameObject buttonClose = GetButton((int)Buttons.Button_Close).gameObject;

        BindEvent(buttonCrossTheBridge, OnButtonCrossTheBridgeClicked, Define.UI.Click);
        BindEvent(buttonCatchTheSpy, OnButtonCatchTheSpyClicked, Define.UI.Click);
        BindEvent(buttonMacMan, OnButtonMacManClicked, Define.UI.Click);
        BindEvent(buttonClose, OnButtonCloseClicked, Define.UI.Click);
    }

    public void OnButtonCloseClicked(PointerEventData data)
    {
        Managers.GetSoundManager.Play("menu_button_click");
        Managers.GetUIManager.ClosePopupUI();
    }

    public void OnButtonCrossTheBridgeClicked(PointerEventData data)
    {
        Managers.GetSoundManager.Play("menu_button_click");
        // �ε��� ���� CrossTheBridge�� �����մϴ�.
        Debug.Log("[StageUI.cs] ���� ���� CrossTheBridge �Դϴ�.");
        GameObject go = Utilize.FindChild(transform.parent.gameObject, "HomeUI", false);
        go.GetComponent<HomeUI>()._scene = Define.Scene.CrossTheBridge;
    }

    public void OnButtonMacManClicked(PointerEventData data)
    {
        Managers.GetSoundManager.Play("menu_button_click");
        // �ε��� ���� MacMan���� �����մϴ�.
        Debug.Log("[StageUI.cs] ���� ���� MacMan �Դϴ�.");
        GameObject go = Utilize.FindChild(transform.parent.gameObject, "HomeUI", false);
        go.GetComponent<HomeUI>()._scene = Define.Scene.MacMan;
    }

    public void OnButtonCatchTheSpyClicked(PointerEventData data)
    {
        Managers.GetSoundManager.Play("menu_button_click");
        // �ε��� ���� CatchTheSpy�� �����մϴ�.
        Debug.Log("[StageUI.cs] ���� ���� CatchTheSpy �Դϴ�.");
        GameObject go = Utilize.FindChild(transform.parent.gameObject, "HomeUI", false);
        go.GetComponent<HomeUI>()._scene = Define.Scene.CatchTheSpy;
    }
}
