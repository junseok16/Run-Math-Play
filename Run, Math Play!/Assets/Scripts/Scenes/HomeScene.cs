using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/**
    @class  : HomeScene
    @date   : 2022-09-02
    @author : Ź�ؼ�
    @brief  : HomeScene���� ������ �� UI�� ȣ���մϴ�.
    @warning: ���ο� ���� ���� ������ [�� �̸� + Scene.cs] ��ũ��Ʈ�� �����ϰ� MonoBehavior ��� BaseScene�� ��ӹ޾ƾ� �մϴ�.
              �� ��ũ��Ʈ���� ����ڿ��� ������ �� UI�� ȣ���մϴ�.
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
