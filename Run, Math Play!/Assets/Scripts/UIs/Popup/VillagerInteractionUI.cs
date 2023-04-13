using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VillagerInteractionUI : PopupUI
{
    public bool _isSpy { get; set; } = false;
    public GameObject _targetVillager;

    private WJ_Mathpid _WJMathpid;
    private GameObject _buttonIsSpy;
    private GameObject _buttonIsNotSpy;
    private TextMeshProUGUI _textSpeaker;
    private TextMeshProUGUI _textConversation;

    public TEXDraw _texDrawQuestion { get; set; } = null;
    public TEXDraw _texDrawAnswer { get; set; } = null;
    public TextMeshProUGUI _textMeshProConversation { get; set; } = null;

    enum Buttons { Button_IsSpy, Button_IsNotSpy, }

    enum Texts { }

    enum TEXDraws { Text_Question, Text_Answer }

    enum TextMeshProUGUIs { Text_Conversation }

    enum Images { Frame_Message }

    enum GameObjects { }

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


        _buttonIsSpy = GetButton((int)Buttons.Button_IsSpy).gameObject;
        _buttonIsNotSpy = GetButton((int)Buttons.Button_IsNotSpy).gameObject;
        GameObject imageMessageFrame = GetImage((int)Images.Frame_Message).gameObject;

        BindEvent(_buttonIsSpy, OnButtonClick_IsSpy, Define.UI.Click);
        BindEvent(_buttonIsNotSpy, OnButtonClick_IsNotSpy, Define.UI.Click);
        BindEvent(imageMessageFrame, OnImageClick_MessageFrame, Define.UI.Click);


        _texDrawQuestion = GetTEXDraw((int)TEXDraws.Text_Question);
        _texDrawAnswer = GetTEXDraw((int)TEXDraws.Text_Answer);
        _textMeshProConversation = GetTextMeshProUGUI((int)TextMeshProUGUIs.Text_Conversation);

        // 스파이 버튼을 비활성화합니다.
        _buttonIsSpy.SetActive(false);
        _buttonIsNotSpy.SetActive(false);

        _texDrawQuestion.gameObject.SetActive(true);
        _texDrawAnswer.gameObject.SetActive(false);

        _textSpeaker = Utilize.FindChild(gameObject, "Text_Speaker", true).GetComponent<TextMeshProUGUI>();
        _textConversation = Utilize.FindChild(gameObject, "Text_Conversation", true).GetComponent<TextMeshProUGUI>();

        _textSpeaker.text = "Player";
        _textConversation.gameObject.SetActive(false); // '입니다!!' 부분을 꺼둠

        // 문제를 요청합니다.
        GetProblemContent();
    }
    
    public void OnImageClick_MessageFrame(PointerEventData data)
    {
        // 플레이어가 말하는 부분에서는 대화창을 눌러 다음 대화로 넘어갈 수 있습니다.
        if (_textSpeaker.text == "Player")
        {
            _textSpeaker.text = "Villager";
            _texDrawAnswer.gameObject.SetActive(true);        
            _textConversation.gameObject.SetActive(true);
            _buttonIsSpy.SetActive(true);
            _buttonIsNotSpy.SetActive(true);
        }
    }

    public void OnButtonClick_IsSpy(PointerEventData data)
    {
        Managers.GetUIManager.ClosePopupUI(this);
        _targetVillager.transform.position = CatchTheSpy.GetInstance.GetPositionNextPrison();// 주민을 감옥으로 이동시킵니다.
        _targetVillager.GetComponent<Villager>()._isActive = false; // 주민이 움직이지 않습니다.
        
        var spyFeedbackUI = Managers.GetUIManager.OpenPopupUI<SpyFeedbackUI>();
        CatchTheSpy.GetInstance.IncreaseCompleteCount();
        
        if (_isSpy == true)
        {
            Managers.GetSoundManager.Play("correct_answer");
            spyFeedbackUI.SetText("스파이입니다!");
            spyFeedbackUI.SetColor(Color.green);
        } 
        else
        {
            Managers.GetSoundManager.Play("wrong_answer");
            CatchTheSpy.GetInstance.IncreaseFailCount();
            spyFeedbackUI.SetText("주민입니다...");
            spyFeedbackUI.SetColor(Color.red);
        }
        CatchTheSpy.GetInstance._remainingVillagerUI.SubtractCount();
    }

    public void OnButtonClick_IsNotSpy(PointerEventData data)
    {
        Managers.GetUIManager.ClosePopupUI(this);
        
        var spyFeedbackUI = Managers.GetUIManager.OpenPopupUI<SpyFeedbackUI>();
        CatchTheSpy.GetInstance.IncreaseCompleteCount();
        
        if (_isSpy == true)
        {
            Managers.GetSoundManager.Play("wrong_answer");
            CatchTheSpy.GetInstance.IncreaseFailCount();
            spyFeedbackUI.SetText("스파이입니다...");
            spyFeedbackUI.SetColor(Color.red);
        }
        else
        {
            Managers.GetSoundManager.Play("correct_answer");
            spyFeedbackUI.SetText("주민입니다!");
            spyFeedbackUI.SetColor(Color.green);
        }
        Destroy(_targetVillager);
        CatchTheSpy.GetInstance._remainingVillagerUI.SubtractCount();
    }
    
    // 서버로부터 문제를 받습니다.
    public void GetProblemContent()
    {
        // Debug.Log("문제를 요청합니다. [1]");
        _WJMathpid.GetProblem("");
    }
}