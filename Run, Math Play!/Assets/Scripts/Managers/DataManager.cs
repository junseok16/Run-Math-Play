using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class : DataManager
    @date  : 2022-09-02
    @author: 탁준석
    @brief : json 파일에서 데이터를 로드합니다.
    @guide : Dictionary 자료구조를 선언합니다.
             Json 파일에서 데이터를 불러와 Dictionary 자료구조에 저장합니다.
             외부에서 Dictionary 자료구조에 접근합니다.
 */

public interface ILoader<Key, Value> { Dictionary<Key, Value> SetDictionary(); }

public class DataManager
{
    // Json 파일을 사용하기 위해 여기에 Dictionary 자료구조를 선언해주세요.
    public Dictionary<int, Data.Exp> expDictionary { get; private set; } = new Dictionary<int, Data.Exp>();

    public Dictionary<int, Data.Text> textDictionary { get; private set; } = new Dictionary<int, Data.Text>();

    // public Dictionary<int, Data.Tutorial> tutorialDictionary { get; private set; } = new Dictionary<int, Data.Tutorial>();

    // public Dictionary<int, Data.Gold> goldDictionary { get; private set; } = new Dictionary<int, Data.Gold>();

    public void Initialize()
    {
        expDictionary = LoadJson<Data.ExpData, int, Data.Exp>("ExpData").SetDictionary();

        textDictionary = LoadJson<Data.TextData, int, Data.Text>("TextData").SetDictionary();

        // tutorialDictionary = LoadJson<Data.TutorialData, int, Data.Tutorial>("TutorialData").SetDictionary();

        // goldDictionary = LoadJson<Data.GoldData, int, Data.Gold>("GoldData").SetDictionary();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.GetResourceManager.Load<TextAsset>($"Data/{ path }");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
