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

    enum Buttons { }// ��ư UI
    enum Texts { }// �ؽ�Ʈ UI
    enum Images { }// �̹��� UI
    enum GameObjects { }// ���� ������Ʈ
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
        Bind<TEXDraw>(typeof(TEXDraws));// TexDraw�� ���ε��մϴ�.
        Bind<TextMeshProUGUI>(typeof(TextMeshProUGUIs));// TextMeshPro�� ���ε��մϴ�.

        _texDrawQuestion = GetTEXDraw((int)TEXDraws.Text_Question);
        // GetCrossTheBridgeProblemContent();
    }

    // 5. UI�� ��ȣ�ۿ����� �� ������ �޼���� �̰��� �������ּ���.
    public void GetCrossTheBridgeProblemContent()
    {
        Debug.Log("[CrossTheBridgeProblemUI.cs] CrossTheBridge ������ ��û�մϴ�.");
        _WJMathpid.GetProblem("");
    }
}
