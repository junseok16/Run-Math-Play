using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/**
    @class  : HomeScene
    @date   : 2022-09-02
    @author : 탁준석
    @brief  : HomeScene에서 보여야 할 UI를 호출합니다.
    @warning: 새로운 신을 만들 때마다 [신 이름 + Scene.cs] 스크립트를 생성하고 MonoBehavior 대신 BaseScene을 상속받아야 합니다.
              이 스크립트에서 사용자에게 보여야 할 UI를 호출합니다.
 */

public class HomeScene : BaseScene
{
    protected override void Initialize()
    {
        base.Initialize();
        _scene = Define.Scene.Home;

        /*
        Managers.GetDataManager.Initialize();
        Dictionary<int, Data.Tutorial> tutorialDict = Managers.GetDataManager.tutorialDictionary;
        Data.Tutorial tutorial;
        tutorialDict.TryGetValue(1, out tutorial);

        if (tutorial.tutorial == true)
        {
            Managers.GetUIManager.OpenPopupUI<TutorialTextUI>();

            List<Data.Tutorial> list = new List<Data.Tutorial>();
            tutorial = new Data.Tutorial(1, false);
            list.Add(tutorial);
            File.WriteAllText("Assets/Resources/Data/TutorialData.json", JsonUtility.ToJson(new Data.TutorialData(list)));
        }
        */
        //PlayerPrefs.SetString("isTutorial", null);
        
        string isTutorial = PlayerPrefs.GetString("isTutorial");
        
        if (isTutorial == "true" ||  isTutorial == "")
        {
            Managers.GetUIManager.OpenPopupUI<TutorialTextUI>();
            PlayerPrefs.SetString("isTutorial", "false");
        }
        
        Managers.GetUIManager.OpenSceneUI<HomeUI>();
    }

    public override void Clear()
    {
    
    }
}
