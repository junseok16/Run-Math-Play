using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PauseUI : PopupUI
{
    WJ_Mathpid _WJMathpid;
    enum Buttons
    {
        Button_Continue,
        Button_GiveUp,
    }

    enum Texts { }

    enum Images { }

    enum GameObjects { }

    private void Start()
    {
        Initialize();
        _WJMathpid = GameObject.Find("@Managers").GetComponent<WJ_Mathpid>();
    }

    public override void Initialize()
    {
        base.Initialize();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));
        
        GameObject buttonContinue = GetButton((int)Buttons.Button_Continue).gameObject;
        GameObject buttonGiveUp = GetButton((int)Buttons.Button_GiveUp).gameObject;

        BindEvent(buttonContinue, OnButtonContinueClicked, Define.UI.Click);
        BindEvent(buttonGiveUp, OnButtonGiveUpClicked, Define.UI.Click);
    }

    public void OnButtonContinueClicked(PointerEventData data)
    {
        Managers.GetUIManager.ClosePopupUI();
    }

    public void OnButtonGiveUpClicked(PointerEventData data)
    {
        _WJMathpid.nth = 1;
        _WJMathpid.OnLearningResult();
        ProblemHit.correct = 0;
        Managers.GetSceneManager.LoadScene(Define.Scene.Home);
    }
}
