using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TutorialDiagnosisUI : PopupUI
{
    [SerializeField] private WJ_Mathpid _WJMathpid;

    public int _level { get; set; } = 0;
    public TEXDraw texDrawQuestion { get; set; } = null;
    public TEXDraw[] texDrawAnswer { get; set; } = new TEXDraw[4];
    public TextMeshProUGUI textMeshProUGUI { get; set; } = null;

    enum Buttons { Button_Answer_00, Button_Answer_01, Button_Answer_02, Button_Answer_03 }// 버튼 UI
    enum Texts { }// 텍스트 UI
    enum Images { }// 이미지 UI
    enum GameObjects { }// 게임 오브젝트
    enum TEXDraws { Text_Question, Text_Answer_00, Text_Answer_01, Text_Answer_02, Text_Answer_03 }
    enum TextMeshProUGUIs { Text_TopFrame_Title }// 텍스트메시프로 UI

    private void Start()
    {
        _WJMathpid = GameObject.Find("@Managers").GetComponent<WJ_Mathpid>();

        if (_WJMathpid != null)
        {
            Debug.Log("[TutorialDiagnosisUI.cs] @Managers 오브젝트가 생성됐습니다.");
        }

        // 사용자가 선택한 수준으로 초기화합니다.
        _WJMathpid.SetDiagnosisLevel(_level);
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));

        Bind<TEXDraw>(typeof(TEXDraws));// 텍스드로우를 바인드합니다.
        Bind<TextMeshProUGUI>(typeof(TextMeshProUGUIs));// 텍스트메시프로를 바인드합니다.

        GameObject buttonAnswer00 = GetButton((int)Buttons.Button_Answer_00).gameObject;
        GameObject buttonAnswer01 = GetButton((int)Buttons.Button_Answer_01).gameObject;
        GameObject buttonAnswer02 = GetButton((int)Buttons.Button_Answer_02).gameObject;
        GameObject buttonAnswer03 = GetButton((int)Buttons.Button_Answer_03).gameObject;

        BindEvent(buttonAnswer00, OnButtonAnswer00Clicked, Define.UI.Click);
        BindEvent(buttonAnswer01, OnButtonAnswer01Clicked, Define.UI.Click);
        BindEvent(buttonAnswer02, OnButtonAnswer02Clicked, Define.UI.Click);
        BindEvent(buttonAnswer03, OnButtonAnswer03Clicked, Define.UI.Click);

        texDrawQuestion = GetTEXDraw((int)TEXDraws.Text_Question);
        texDrawAnswer[0] = GetTEXDraw((int)TEXDraws.Text_Answer_00);
        texDrawAnswer[1] = GetTEXDraw((int)TEXDraws.Text_Answer_01);
        texDrawAnswer[2] = GetTEXDraw((int)TEXDraws.Text_Answer_02);
        texDrawAnswer[3] = GetTEXDraw((int)TEXDraws.Text_Answer_03);
        textMeshProUGUI = GetTextMeshProUGUI((int)TextMeshProUGUIs.Text_TopFrame_Title);
    }

    public void OnButtonAnswer00Clicked(PointerEventData data)
    {
        // 첫 번째 보기를 선택했고 다음 문제를 출제합니다.   
        _WJMathpid.GetProblem(texDrawAnswer[0].text);
        Managers.GetSoundManager.Play("menu_button_click");
    }

    public void OnButtonAnswer01Clicked(PointerEventData data)
    {
        // 두 번째 보기를 선택했고 다음 문제를 출제합니다.
        _WJMathpid.GetProblem(texDrawAnswer[1].text);
        Managers.GetSoundManager.Play("menu_button_click");
    }

    public void OnButtonAnswer02Clicked(PointerEventData data)
    {
        // 세 번째 보기를 선택했고 다음 문제를 출제합니다.
        _WJMathpid.GetProblem(texDrawAnswer[2].text);
        Managers.GetSoundManager.Play("menu_button_click");
    }

    public void OnButtonAnswer03Clicked(PointerEventData data)
    {
        // 네 번째 보기를 선택했고 다음 문제를 출제합니다.
        _WJMathpid.GetProblem(texDrawAnswer[3].text);
        Managers.GetSoundManager.Play("menu_button_click");
    }
}