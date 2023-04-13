using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameClearUI : PopupUI
{
    WJ_Mathpid _WJMathpid = null;

    enum Buttons { }

    enum Texts { }

    enum Images { ScreenDim }

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
        
        GameObject screenDim = GetImage((int)Images.ScreenDim).gameObject;
        BindEvent(screenDim, OnScreenClicked, Define.UI.Click);
    }
    
    public void OnScreenClicked(PointerEventData data)
    {
        Define.Scene _scene = Managers.GetSceneManager.BaseScene._scene;
        if (_scene == Define.Scene.CatchTheSpy || _scene == Define.Scene.MacMan)
        {
            _WJMathpid.OnLearningResult();
        }

        Managers.GetUIManager.ClosePopupUI();
        Managers.GetSceneManager.LoadScene(Define.Scene.Home);
    }

    public void SetTime(string time)
    {
        var textTime = Utilize.FindChild(gameObject, "Text_Time", true).GetComponent<TextMeshProUGUI>();
        textTime.text = time;
    }

    public void SetAccuracy(int accuracy)
    {
        Utilize.FindChild(gameObject, "Text_CorrectWrong", true).SetActive(false);
        Utilize.FindChild(gameObject, "Text_CorrectWrongNm", true).SetActive(false);
        var textAccuracy = Utilize.FindChild(gameObject, "Text_Accuracy", true).GetComponent<TextMeshProUGUI>();
        textAccuracy.text = accuracy + "%";
    }

    public void SetCorrectWrong(int question, int correct, int wrong)
    {
        Utilize.FindChild(gameObject, "Text_Accuracy", true).SetActive(false);
        Utilize.FindChild(gameObject, "Text_AccuracyNm", true).SetActive(false);
        var textCorrectWrong = Utilize.FindChild(gameObject, "Text_CorrectWrong", true).GetComponent<TextMeshProUGUI>();
        textCorrectWrong.text = question + "/" + correct + "/" + wrong;
    }
}
