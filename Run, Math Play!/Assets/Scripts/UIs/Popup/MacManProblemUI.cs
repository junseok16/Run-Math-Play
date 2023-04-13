using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MacManProblemUI : PopupUI
{
    private WJ_Mathpid _WJMathpid = null;
    public TextMeshProUGUI _textMeshProScore = null;
    public TextMeshProUGUI _textMeshProCorrect = null;
    public TextMeshProUGUI _textMeshProWrong = null;
    public TEXDraw[] _texDrawAnswer { get; set; } = new TEXDraw[4];
    public TEXDraw _texDrawQuestion = null;

    //Text correctText;
    //Text wrongText;

    enum Buttons { }// 버튼 UI
    enum Texts { }// 텍스트 UI
    enum Images { }// 이미지 UI
    enum GameObjects { }// 게임 오브젝트
    enum TextMeshProUGUIs { Text_Score, Correct_Text, Wrong_Text }
    enum TEXDraws { Text_Purple, Text_Red, Text_Blue, Text_Green, Text_Question }

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

        _textMeshProScore = GetTextMeshProUGUI((int)TextMeshProUGUIs.Text_Score);
        _textMeshProCorrect = GetTextMeshProUGUI((int)TextMeshProUGUIs.Correct_Text);
        _textMeshProWrong = GetTextMeshProUGUI((int)TextMeshProUGUIs.Wrong_Text);

        _texDrawAnswer[0] = GetTEXDraw((int)TEXDraws.Text_Purple);
        _texDrawAnswer[1] = GetTEXDraw((int)TEXDraws.Text_Red);
        _texDrawAnswer[2] = GetTEXDraw((int)TEXDraws.Text_Blue);
        _texDrawAnswer[3] = GetTEXDraw((int)TEXDraws.Text_Green);
        _texDrawQuestion = GetTEXDraw((int)TEXDraws.Text_Question);

        // 문제를 요청합니다.
        GetMacManProblemContent();

        // 정답 유무 텍스트
        //correctText = GameObject.Find("Correct_Text").GetComponent<Text>();
        //wrongText = GameObject.Find("Wrong_Text").GetComponent<Text>();
    }

    public void GetMacManProblemContent()
    {
        _WJMathpid.GetProblem("");
    }
}
