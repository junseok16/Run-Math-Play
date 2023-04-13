using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoginUI : SceneUI
{
    enum Buttons { Login_Button }
    enum Texts { }
    enum Images { Background_Image }
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

        GameObject buttonLogin = GetButton((int)Buttons.Login_Button).gameObject;
        BindEvent(buttonLogin, OnButtonLoginClicked, Define.UI.Click);

    }

    public void OnButtonLoginClicked(PointerEventData data)
    {
        Managers.GetUIManager.OpenSceneUI<HomeUI>();
    }
}
