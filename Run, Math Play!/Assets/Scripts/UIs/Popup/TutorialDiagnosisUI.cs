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

    enum Buttons { Button_Answer_00, Button_Answer_01, Button_Answer_02, Button_Answer_03 }// ��ư UI
    enum Texts { }// �ؽ�Ʈ UI
    enum Images { }// �̹��� UI
    enum GameObjects { }// ���� ������Ʈ
    enum TEXDraws { Text_Question, Text_Answer_00, Text_Answer_01, Text_Answer_02, Text_Answer_03 }
    enum TextMeshProUGUIs { Text_TopFrame_Title }// �ؽ�Ʈ�޽����� UI

    private void Start()
    {
        _WJMathpid = GameObject.Find("@Managers").GetComponent<WJ_Mathpid>();

        if (_WJMathpid != null)
        {
            Debug.Log("[TutorialDiagnosisUI.cs] @Managers ������Ʈ�� �����ƽ��ϴ�.");
        }

        // ����ڰ� ������ �������� �ʱ�ȭ�մϴ�.
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

        Bind<TEXDraw>(typeof(TEXDraws));// �ؽ���ο츦 ���ε��մϴ�.
        Bind<TextMeshProUGUI>(typeof(TextMeshProUGUIs));// �ؽ�Ʈ�޽����θ� ���ε��մϴ�.

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
        // ù ��° ���⸦ �����߰� ���� ������ �����մϴ�.   
        _WJMathpid.GetProblem(texDrawAnswer[0].text);
        Managers.GetSoundManager.Play("menu_button_click");
    }

    public void OnButtonAnswer01Clicked(PointerEventData data)
    {
        // �� ��° ���⸦ �����߰� ���� ������ �����մϴ�.
        _WJMathpid.GetProblem(texDrawAnswer[1].text);
        Managers.GetSoundManager.Play("menu_button_click");
    }

    public void OnButtonAnswer02Clicked(PointerEventData data)
    {
        // �� ��° ���⸦ �����߰� ���� ������ �����մϴ�.
        _WJMathpid.GetProblem(texDrawAnswer[2].text);
        Managers.GetSoundManager.Play("menu_button_click");
    }

    public void OnButtonAnswer03Clicked(PointerEventData data)
    {
        // �� ��° ���⸦ �����߰� ���� ������ �����մϴ�.
        _WJMathpid.GetProblem(texDrawAnswer[3].text);
        Managers.GetSoundManager.Play("menu_button_click");
    }
}