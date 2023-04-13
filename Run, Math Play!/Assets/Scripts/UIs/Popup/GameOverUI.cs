using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class GameOverUI : PopupUI
{
    WJ_Mathpid _WJMathpid = null;
    enum Buttons { }

    enum Texts { }

    enum Images { }

    enum GameObjects { }
    enum TextMeshProUGUIs { Text_Back }// 텍스트메시프로 UI


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
        Bind<TextMeshProUGUI>(typeof(TextMeshProUGUIs));// 텍스트메시프로를 바인드합니다.

        GameObject TextBack = GetTextMeshProUGUI((int)TextMeshProUGUIs.Text_Back).gameObject;
        BindEvent(TextBack, OnTextBackClicked, Define.UI.Click);
    }

    public void OnTextBackClicked(PointerEventData data)
    {
        _WJMathpid.nth = 1;
        _WJMathpid.OnLearningResult();
        ProblemHit.correct = 0;
        Managers.GetUIManager.ClosePopupUI();
        Managers.GetSceneManager.LoadScene(Define.Scene.Home);
    }
}