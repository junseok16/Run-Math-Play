using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TutorialTextUI : PopupUI
{
    Dictionary<int, Data.Text> textDict = null;
    public int _conversation { get; set; } = 0;
    enum Buttons { Button_NextText, Button_Level_A, Button_Level_B, Button_Level_C, Button_Level_D }// ��ư UI
    enum Texts { }// �ؽ�Ʈ UI
    enum Images { }// �̹��� UI
    enum GameObjects { GameObject_Level }// ���� ������Ʈ

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
        
        GameObject buttonNext = GetButton((int)Buttons.Button_NextText).gameObject;
        GameObject buttonLevelA = GetButton((int)Buttons.Button_Level_A).gameObject;
        GameObject buttonLevelB = GetButton((int)Buttons.Button_Level_B).gameObject;
        GameObject buttonLevelC = GetButton((int)Buttons.Button_Level_C).gameObject;
        GameObject buttonLevelD = GetButton((int)Buttons.Button_Level_D).gameObject;
        GameObject gameObjectLevel = GetGameObject((int)GameObjects.GameObject_Level).gameObject;

        gameObjectLevel.SetActive(false);

        BindEvent(buttonNext, OnbuttonNextClicked, Define.UI.Click);
        BindEvent(buttonLevelA, OnbuttonLevelAClicked, Define.UI.Click);
        BindEvent(buttonLevelB, OnbuttonLevelBClicked, Define.UI.Click);
        BindEvent(buttonLevelC, OnbuttonLevelCClicked, Define.UI.Click);
        BindEvent(buttonLevelD, OnbuttonLevelDClicked, Define.UI.Click);

        textDict = Managers.GetDataManager.textDictionary;
    }

    public void OnbuttonNextClicked(PointerEventData data)
    {
        GameObject go = Utilize.FindChild(gameObject, "Text_Conversation", true); ;
        GameObject gameObjectLevel = GetGameObject((int)GameObjects.GameObject_Level).gameObject; ;
        GameObject buttonNext = GetButton((int)Buttons.Button_NextText).gameObject; ;

        switch (_conversation)
        {
            case 0:
                go.GetComponent<TextMeshProUGUI>().text = "���� �����ϴ� ������ �����ΰ���?\n�������ּ���.";
                buttonNext.SetActive(false);
                gameObjectLevel.SetActive(true);
                _conversation++;
                break;

            case 1:
                gameObjectLevel.SetActive(false);
                go.GetComponent<TextMeshProUGUI>().text = "��� �������. ���� �ž� �÷��̸� �غ����?";
                _conversation++;
                break;

            case 2:
                Managers.GetUIManager.ClosePopupUI();
                break;
        }
    }

    public void OnbuttonLevelAClicked(PointerEventData data)
    {
        Managers.GetUIManager.ClosePopupUI();
        TutorialDiagnosisUI tui = Managers.GetUIManager.OpenPopupUI<TutorialDiagnosisUI>();
        tui._level = 0;
        Managers.GetSoundManager.Play("menu_button_click");
    }

    public void OnbuttonLevelBClicked(PointerEventData data)
    {
        Managers.GetUIManager.ClosePopupUI();
        TutorialDiagnosisUI tui = Managers.GetUIManager.OpenPopupUI<TutorialDiagnosisUI>();
        tui._level = 1;
        Managers.GetSoundManager.Play("menu_button_click");
    }

    public void OnbuttonLevelCClicked(PointerEventData data)
    {
        Managers.GetUIManager.ClosePopupUI();
        TutorialDiagnosisUI tui = Managers.GetUIManager.OpenPopupUI<TutorialDiagnosisUI>();
        tui._level = 2;
        Managers.GetSoundManager.Play("menu_button_click");
    }

    public void OnbuttonLevelDClicked(PointerEventData data)
    {
        Managers.GetUIManager.ClosePopupUI();
        TutorialDiagnosisUI tui = Managers.GetUIManager.OpenPopupUI<TutorialDiagnosisUI>();
        tui._level = 3;
        Managers.GetSoundManager.Play("menu_button_click");
    }
}