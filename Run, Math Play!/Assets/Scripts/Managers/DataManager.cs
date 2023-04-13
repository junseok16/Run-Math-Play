using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    @class : DataManager
    @date  : 2022-09-02
    @author: Ź�ؼ�
    @brief : json ���Ͽ��� �����͸� �ε��մϴ�.
    @guide : Dictionary �ڷᱸ���� �����մϴ�.
             Json ���Ͽ��� �����͸� �ҷ��� Dictionary �ڷᱸ���� �����մϴ�.
             �ܺο��� Dictionary �ڷᱸ���� �����մϴ�.
 */

public interface ILoader<Key, Value> { Dictionary<Key, Value> SetDictionary(); }

public class DataManager
{
    // Json ������ ����ϱ� ���� ���⿡ Dictionary �ڷᱸ���� �������ּ���.
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
