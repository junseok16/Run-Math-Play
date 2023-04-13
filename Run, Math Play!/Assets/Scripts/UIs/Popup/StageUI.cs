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
        // 로드할 맵을 CrossTheBridge로 설정합니다.
        Debug.Log("[StageUI.cs] 다음 신은 CrossTheBridge 입니다.");
        GameObject go = Utilize.FindChild(transform.parent.gameObject, "HomeUI", false);
        go.GetComponent<HomeUI>()._scene = Define.Scene.CrossTheBridge;
    }

    public void OnButtonMacManClicked(PointerEventData data)
    {
        Managers.GetSoundManager.Play("menu_button_click");
        // 로드할 맵을 MacMan으로 설정합니다.
        Debug.Log("[StageUI.cs] 다음 신은 MacMan 입니다.");
        GameObject go = Utilize.FindChild(transform.parent.gameObject, "HomeUI", false);
        go.GetComponent<HomeUI>()._scene = Define.Scene.MacMan;
    }

    public void OnButtonCatchTheSpyClicked(PointerEventData data)
    {
        Managers.GetSoundManager.Play("menu_button_click");
        // 로드할 맵을 CatchTheSpy로 설정합니다.
        Debug.Log("[StageUI.cs] 다음 신은 CatchTheSpy 입니다.");
        GameObject go = Utilize.FindChild(transform.parent.gameObject, "HomeUI", false);
        go.GetComponent<HomeUI>()._scene = Define.Scene.CatchTheSpy;
    }
}
