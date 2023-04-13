using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HomeUI : SceneUI
{
    public Define.Scene _scene { get; set; } = Define.Scene.Unknown;

    enum Buttons
    {
        // StatusBar_Group_ColorButton

        // Button_Exit
        Button_Exit,

        // Button_SubMenu

        // Button_MainMenu

        // Buttons_Group
        Button_Stage,
        Button_Start,
    }

    enum Texts {  }

    enum Images {  }

    enum GameObjects {  }

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

        GameObject buttonExit = GetButton((int)Buttons.Button_Exit).gameObject;
        GameObject buttonStage = GetButton((int)Buttons.Button_Stage).gameObject;
        GameObject buttonStart = GetButton((int)Buttons.Button_Start).gameObject;

        BindEvent(buttonExit, OnButtonExitClicked, Define.UI.Click);
        BindEvent(buttonStage, OnButtonStageClicked, Define.UI.Click);
        BindEvent(buttonStart, OnButtonStartClicked, Define.UI.Click);
    }

    public void OnButtonExitClicked(PointerEventData data)
    {
        Managers.GetSoundManager.Play("menu_button_click");
        PlayerPrefs.SetString("isTutorial", "true");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        // Managers.GetUIManager.OpenPopupUI<SettingsUI>();
    }

    public void OnButtonCollectionClicked(PointerEventData data)
    {
        Managers.GetSoundManager.Play("menu_button_click");
        Managers.GetSceneManager.LoadScene(Define.Scene.Collection);
    }

    public void OnButtonStageClicked(PointerEventData data)
    {
        Managers.GetSoundManager.Play("menu_button_click");
        Managers.GetUIManager.OpenPopupUI<StageUI>();
    }

    public void OnButtonStartClicked(PointerEventData data)
    {
        Managers.GetSoundManager.Play("menu_button_click");
        if (_scene == Define.Scene.Unknown) { return; }
        Managers.GetSceneManager.LoadScene(_scene);
    }
}