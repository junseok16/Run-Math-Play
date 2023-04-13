using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseButtonUI : SceneUI
{
    enum Buttons { Button_Pause }

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

        GameObject buttonPause = GetButton((int)Buttons.Button_Pause).gameObject;

        BindEvent(buttonPause, OnButtonPauseClicked, Define.UI.Click);
    }

    public void OnButtonPauseClicked(PointerEventData data)
    {
        Managers.GetUIManager.OpenPopupUI<PauseUI>();
        Managers.GetSoundManager.Play("menu_button_click");
    }
}
