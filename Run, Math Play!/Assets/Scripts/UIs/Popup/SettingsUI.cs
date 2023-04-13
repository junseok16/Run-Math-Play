using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SettingsUI : PopupUI
{
    enum Buttons { Button_Close }

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

        GameObject buttonClose = GetButton((int)Buttons.Button_Close).gameObject;
        BindEvent(buttonClose, OnButtonCloseClicked, Define.UI.Click);
    }

    public void OnButtonCloseClicked(PointerEventData data)
    {
        Managers.GetUIManager.ClosePopupUI();
    }
}
