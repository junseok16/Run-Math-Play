using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CrossTheBridgeProblemUI : PopupUI
{
    private WJ_Mathpid _WJMathpid;
    public TEXDraw _texDrawQuestion = null;

    enum Buttons { }// 버튼 UI
    enum Texts { }// 텍스트 UI
    enum Images { }// 이미지 UI
    enum GameObjects { }// 게임 오브젝트
    enum TextMeshProUGUIs { Text_Score }
    enum TEXDraws { Text_Question }

    private void Start()
    {
        _WJMathpid = GameObject.Find("@Managers").GetComponent<WJ_Mathpid>();
        _WJMathpid.SetLearning();
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));
        Bind<TEXDraw>(typeof(TEXDraws));// TexDraw를 바인드합니다.
        Bind<TextMeshProUGUI>(typeof(TextMeshProUGUIs));// TextMeshPro를 바인드합니다.

        _texDrawQuestion = GetTEXDraw((int)TEXDraws.Text_Question);
        // GetCrossTheBridgeProblemContent();
    }

    // 5. UI와 상호작용했을 때 실행할 메서드는 이곳에 정의해주세요.
    public void GetCrossTheBridgeProblemContent()
    {
        Debug.Log("[CrossTheBridgeProblemUI.cs] CrossTheBridge 문제를 요청합니다.");
        _WJMathpid.GetProblem("");
    }
}
